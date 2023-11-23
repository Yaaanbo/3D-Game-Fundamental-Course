using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform cannonBodyTransform;

    private float yDegrees, zDegrees;

    // Update is called once per frame
    void Update()
    {
        CannonMovementHandler();
    }

    private void CannonMovementHandler()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        yDegrees += vertical * rotationSpeed * Time.deltaTime;
        zDegrees += horizontal * rotationSpeed * Time.deltaTime;

        float minimumYAngle = -10f, maximumYAngle = 45f;
        float minimumZAngle = -35f, maximumZAngle = 35f;
        yDegrees = Mathf.Clamp(yDegrees, minimumYAngle, maximumYAngle);
        zDegrees = Mathf.Clamp(zDegrees, minimumZAngle, maximumZAngle);

        cannonBodyTransform.localEulerAngles = new Vector3(0, yDegrees, zDegrees);
    }
}
