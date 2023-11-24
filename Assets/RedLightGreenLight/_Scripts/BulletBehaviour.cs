using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [HideInInspector] public Transform targetPlayer;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, targetPlayer.position, bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.OnPlayerDead();
            Destroy(this.gameObject);
        }
    }
}
