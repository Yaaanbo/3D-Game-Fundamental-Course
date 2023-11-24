using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollBehaviour : MonoBehaviour
{
    [Header("Red Light Green Light")]
    [SerializeField] private float minTimer, maxTimer;
    [HideInInspector] public bool isGreenLight = true;

    [Header("Shooting")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootPoint;
    private bool isShooting = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeLight());
    }

    private IEnumerator ChangeLight()
    {
        float randomTimer = Random.Range(minTimer, maxTimer);
        yield return new WaitForSeconds(randomTimer);

        isGreenLight = !isGreenLight;
        Debug.Log("Is Green Light : " + isGreenLight);

        StartCoroutine(ChangeLight());
    }

    public void ShootPlayer(Transform _target)
    {
        if (isShooting) return;

        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        bullet.GetComponent<BulletBehaviour>().targetPlayer = _target;
        isShooting = true;
    }
}
