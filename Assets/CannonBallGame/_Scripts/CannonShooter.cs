using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooter : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CannonAmmo cannonAmmo;

    [Header("Shooter components")]
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
        if (cannonAmmo.CurrentAmmo <= 0) return;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject cannonBall = Instantiate(cannonBallPrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody cannonBallRb = cannonBall.GetComponent<Rigidbody>();
            cannonBallRb.AddForce(cannonBall.transform.forward * shootForce, ForceMode.Impulse);

            float selfDestroyDuration = 5f;
            Destroy(cannonBall, selfDestroyDuration);

            cannonAmmo.CurrentAmmo--;
        }
    }
}
