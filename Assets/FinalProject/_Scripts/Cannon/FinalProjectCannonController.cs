using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalProjectCannonController : MonoBehaviour
{
    [Header("Cannon Components")]
    [SerializeField] private Transform cannonBody;
    
    [Header("Cannon value")]
    [SerializeField] private float rotationSpeed;
    [SerializeField] private bool isVerticallyInversed;
    private float yDegrees, zDegrees;

    public bool isSelected { get; set; }

    // Update is called once per frame
    void Update()
    {
        RotateCannon();
    }

    private void RotateCannon()
    {
        if (!isSelected) return;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (isVerticallyInversed)
            yDegrees += vertical * -rotationSpeed * Time.deltaTime;
        else
            yDegrees += vertical * rotationSpeed * Time.deltaTime;

        zDegrees += horizontal * rotationSpeed * Time.deltaTime;

        float minYDegrees = 0f, maxYDegrees = 45f;
        yDegrees = Mathf.Clamp(yDegrees, minYDegrees, maxYDegrees);

        float minZDegrees = -45f, maxZDegrees = 45f;
        zDegrees = Mathf.Clamp(zDegrees, minZDegrees, maxZDegrees);

        cannonBody.localEulerAngles = new Vector3(0, yDegrees, zDegrees);
    }
}
