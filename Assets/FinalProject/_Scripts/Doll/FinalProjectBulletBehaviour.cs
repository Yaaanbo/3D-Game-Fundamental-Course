using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalProjectBulletBehaviour : MonoBehaviour
{
    private const string CANNON_BULLET_TAG = "FP_CannonBullet";

    [Header("Bullet values")]
    [SerializeField] private float bulletSpeed;

    [Header("Particle system")]
    [SerializeField] private GameObject collidingParticle;

    public Transform playerTarget { get; set; }
    private Vector3 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        moveDir = playerTarget.position - this.transform.position;
    }

    private void Update()
    {
        this.transform.position += moveDir.normalized * bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<FinalProjectPlayerController>(out FinalProjectPlayerController player))
        {
            if (!FinalProjectGameManager.singleton.hasWon)
            {
                player.OnPlayerDead();
                Destroy(this.gameObject);
            }
        }

        if (other.CompareTag(CANNON_BULLET_TAG))
        {
            GameObject collideParticleGO = Instantiate(collidingParticle, this.transform.position, Quaternion.identity);

            float particleDestroyTime = 3f;
            Destroy(collideParticleGO, particleDestroyTime);

            Destroy(this.gameObject);
            Destroy(other.gameObject);

        }
    }
}
