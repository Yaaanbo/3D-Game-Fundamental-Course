using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private DollBehaviour doll;
    [SerializeField] private CameraFollow camFoll;

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

    private bool isDead = false;
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

            if (!doll.isGreenLight)
            {
                StartCoroutine(DollShoot());
            }
                
        }
    }

    public void OnPlayerDead()
    {
        camFoll.playerTarget = ragdollHips;
        playerBody.SetActive(false);
        ragdollBody.SetActive(true);
        isDead = true;
    }

    private IEnumerator DollShoot()
    {
        float waitTime = .7f;
        yield return new WaitForSeconds(waitTime);
        doll.ShootPlayer(this.transform);
    }
}
