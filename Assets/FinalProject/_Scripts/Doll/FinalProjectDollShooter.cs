using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalProjectDollShooter : MonoBehaviour
{
    [Header("Player Transform")]
    [SerializeField] private Transform playerTransform;

    [Header("Doll Components")]
    [SerializeField] private Transform shotPoint;

    [Header("Bullet Components")]
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private float minDelay;
    [SerializeField] private float maxDelay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DollShot());
    }

    private IEnumerator DollShot()
    {
        float randomShotTime = Random.Range(minDelay, maxDelay);
        yield return new WaitForSeconds(randomShotTime);

        GameObject bulletGO = Instantiate(bulletPrefabs, shotPoint.position, Quaternion.identity);

        FinalProjectBulletBehaviour bulletBehaviour = bulletGO.GetComponent<FinalProjectBulletBehaviour>();
        bulletBehaviour.playerTarget = playerTransform;

        float destroyTime = 7f;
        Destroy(bulletGO, destroyTime);

        StartCoroutine(DollShot());
    }
}
