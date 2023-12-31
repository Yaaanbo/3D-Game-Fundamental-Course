using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalProjectCannonShooter : MonoBehaviour
{
    [Header("Cannon components")]
    [SerializeField] private FinalProjectCannonController cannonController;
    [SerializeField] private Transform shootingPoint;

    [Header("Bullet")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootForce;

    [Header("Audio")]
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip shotSFX;

    // Update is called once per frame
    void Update()
    {
        ShootingHandler();
    }

    private void ShootingHandler()
    {
        if (Input.GetMouseButtonDown(0) && cannonController.isSelected)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * shootForce, ForceMode.Impulse);

            source.PlayOneShot(shotSFX);

            Destroy(bullet, 5f);
        }
    }
}
