using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlassBridgePlayerController : MonoBehaviour
{
    private const string FALLING_DETECTOR_TAG = "FallDetector";
    private const string ROOM_GROUND_TAG = "RoomGround";
    private const string FINISH_LINE_TAG = "FinishColl";

    [Header("Class Reference")]
    [SerializeField] private GlassBridgePlayerAudio playerAudio;

    [Header("Movement")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float rotationSmoothTime = .125f;
    private float turnSmoothVelocity;

    [Header("Jumping")]
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float jumpHeight = 3f;
    private Vector3 velocity;

    [Header("Ground Checker")]
    [SerializeField] private Transform groundChecker;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float groundCheckerRadius;

    [Header("Ragdoll")]
    [SerializeField] private CapsuleCollider capsuleCol;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject realBody;
    [SerializeField] private GameObject ragdollBody;
    [SerializeField] private Transform ragdollHips;

    private bool isCanMove = true;
    public bool isFalling { get; private set; }
    public bool isGrounded { get; private set; }
    public bool isRunning { get; private set; }

    public Action OnPlayerWon;

    // Update is called once per frame
    void Update()
    {
        MovementHandler();
    }

    private void MovementHandler()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        isRunning = (direction.magnitude >= .1f);
        if (isRunning && !isFalling && isCanMove)
        {
            float targetAngle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(this.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, rotationSmoothTime);
            this.transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f).normalized * Vector3.forward;
            controller.Move(moveDir * movementSpeed * Time.deltaTime);
        }

        JumpingAndGravityHandler();
    }

    private void JumpingAndGravityHandler()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, groundCheckerRadius, groundMask);

        if (isGrounded && velocity.y < 0) velocity.y = -2f;

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            playerAudio.PlaySFX(0);
        }
    }

    private void OnPlayerDead()
    {
        realBody.SetActive(false);
        ragdollBody.SetActive(true);
        Camera.main.GetComponent<CameraFollow>().playerTarget = ragdollHips;

        controller.enabled = false;
        capsuleCol.center = new Vector3(0f, 0f, 0f);
        rb.useGravity = true;

        playerAudio.PlaySFX(2);

        StartCoroutine(RestartGame());

        IEnumerator RestartGame()
        {
            float waitTime = 3f;
            yield return new WaitForSeconds(waitTime);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(FALLING_DETECTOR_TAG))
        {
            isFalling = true;

            float fallingControllerHeight = .3f;
            controller.height = fallingControllerHeight;
            Debug.Log("PlayerFalling");
        }

        if (other.CompareTag(ROOM_GROUND_TAG))
        {
            OnPlayerDead();
        }

        if (other.CompareTag(FINISH_LINE_TAG))
        {
            OnPlayerWon?.Invoke();
        }

        if (other.transform.TryGetComponent<GlassBehaviour>(out GlassBehaviour glass))
        {
            if (glass.isBreakable)
            {
                isFalling = true;

                Debug.Log("Glass is breakable");
                glass.BreakGlass();
                playerAudio.PlaySFX(1);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundChecker.position, groundCheckerRadius);
    }
}
