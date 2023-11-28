using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalProjectPlayerController : MonoBehaviour
{
    private const string CANNON_GROUNDTAG = "FP_PlayerPos";

    [Header("Cannon Components")]
    [SerializeField] private Transform[] cannonGrounds;
    private int currentGroundIndex;

    [Header("Player Components")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float jumpForce;
    public bool isJumping { get; private set; }
    private bool isCanJump = true;
   
    // Update is called once per frame
    void Update()
    {
        ChangeGround();
    }

    private void ChangeGround()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentGroundIndex == 1 || isJumping) return;
            currentGroundIndex++;
            StartCoroutine(PressJump());

            Debug.Log("Current ground index : " + currentGroundIndex);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentGroundIndex == 0 || isJumping) return;
            currentGroundIndex--;
            StartCoroutine(PressJump());

            Debug.Log("Current ground index : " + currentGroundIndex);
        }

        MoveJump();
    }

    private IEnumerator PressJump()
    {
        isJumping = true;
        float waitTime = .5f;
        yield return new WaitForSeconds(waitTime);

        isCanJump = false;
        rb.velocity = Vector3.up * jumpForce;
    }

    private void MoveJump()
    {
        if (!isJumping || isCanJump) return;

        float moveSpeed = 2.5f;
        this.transform.position = Vector3.MoveTowards(this.transform.position, cannonGrounds[currentGroundIndex].position, moveSpeed * Time.deltaTime);

        float maxDistance = .1f;
        if (Vector3.Distance(this.transform.position, cannonGrounds[currentGroundIndex].position) < maxDistance)
        {
            isJumping = false;
            isCanJump = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(CANNON_GROUNDTAG))
        {
            FinalProjectCannonController selectedCannon = other.GetComponentInParent<FinalProjectCannonController>();
            selectedCannon.isSelected = true;

            Debug.Log("Cannon Selected");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(CANNON_GROUNDTAG))
        {
            FinalProjectCannonController selectedCannon = other.GetComponentInParent<FinalProjectCannonController>();
            selectedCannon.isSelected = false;

            Debug.Log("Cannon Deselected");
        }
    }
}
