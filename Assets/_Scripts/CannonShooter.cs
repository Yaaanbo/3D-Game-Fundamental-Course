using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooter : MonoBehaviour
{
    [SerializeField] private GameObject cannonBallPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootForce;


    // Update is called once per frame
    void Update()
    {
        ShootingHandler();
    }

    private void ShootingHandler()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject cannonBall = Instantiate(cannonBallPrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody cannonBallRb = cannonBall.GetComponent<Rigidbody>();
            cannonBallRb.AddForce(cannonBall.transform.forward * shootForce, ForceMode.Impulse);

            float selfDestroyDuration = 5f;
            Destroy(cannonBall, selfDestroyDuration);
        }
    }
}
