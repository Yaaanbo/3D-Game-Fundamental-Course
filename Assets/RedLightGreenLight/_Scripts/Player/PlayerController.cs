using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private const string FINISH_LINE_TAG = "FinishLine";

    [Header("Reference")]
    [SerializeField] private DollBehaviour doll;
    [SerializeField] private CameraFollow camFoll;
    [SerializeField] private PlayerAudio playerAudio;

    [Header("Movement")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSmoothTime = .125f;
    private float turnSmoothVelocity;

    [Header("Anim threshold")]
    [HideInInspector] public float animThreshold;

    [Header("Player Body")]
    [SerializeField] private GameObject playerBody;
    [SerializeField] private GameObject ragdollBody;
    [SerializeField] private Transform ragdollHips;

    [Header("Dead Particle")]
    [SerializeField] private ParticleSystem bloodPartcile;

    private bool isDead = false;
    private bool hasWon = false;

    public Action OnPlayerWon;
    // Update is called once per frame
    void Update()
    {
        MovementHandler();
    }

    private void MovementHandler()
    {
        if (isDead) return;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= .1f)
        {
            float targetAngle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(this.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, rotationSmoothTime);
            this.transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f).normalized * Vector3.forward;
            controller.Move(moveDir * movementSpeed * Time.deltaTime);

            animThreshold = new Vector2(horizontal, vertical).magnitude;

            if (!doll.isGreenLight && !hasWon)
            {
                StartCoroutine(DollShoot());
            }
        }
    }

    public void OnPlayerDead()
    {
        bloodPartcile.Play();

        playerAudio.PlayDeadAudio();
        
        camFoll.playerTarget = ragdollHips;
        
        playerBody.SetActive(false);
        ragdollBody.SetActive(true);
        
        isDead = true;

        StartCoroutine(RestartGame());
    }

    private IEnumerator DollShoot()
    {
        float waitTime = .7f;
        yield return new WaitForSeconds(waitTime);
        doll.ShootPlayer(this.transform);
    }

    private IEnumerator RestartGame()
    {
        float waitTime = 3f;
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(FINISH_LINE_TAG))
        {
            hasWon = true;
            OnPlayerWon?.Invoke();
            StartCoroutine(RestartGame());
        }
    }
}
