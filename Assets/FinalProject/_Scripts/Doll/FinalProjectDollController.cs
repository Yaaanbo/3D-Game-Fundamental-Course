using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalProjectDollController : MonoBehaviour
{
    private const string CANNON_BALL_TAG = "FP_CannonBullet";

    [Header("Doll value")]
    [SerializeField] private float moveSpeed;

    [Header("Waypoints")]
    [SerializeField] private Transform[] waypoints;
    private int currentWaypointIndex = 0;

    [Header("Doll Lives")]
    private float dollHp;
    [SerializeField] private float dollMaxHp = 350f;
    [SerializeField] private Transform deadParticlePos;
    [SerializeField] private GameObject onDeadParticle;

    [Header("Events")]
    public Action<float, float> OnDollHit;
    public Action OnDollDead;

    private void Start()
    {
        dollHp = dollMaxHp;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveToWaypoint();
    }

    private void MoveToWaypoint()
    {
        Vector3 moveDir = waypoints[currentWaypointIndex].position - this.transform.position;
        Vector3 velocity = moveDir.normalized * moveSpeed * Time.deltaTime;
        this.transform.position += velocity;

        float distance = Vector3.Distance(this.transform.position, waypoints[currentWaypointIndex].position);
        float maxDistance = .2f;

        if(distance < maxDistance)
        {
            currentWaypointIndex++;

            if(currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(CANNON_BALL_TAG))
        {
            Destroy(other.gameObject);
            dollHp -= 25f;

            OnDollHit?.Invoke(dollHp, dollMaxHp);

            if(dollHp <= 0)
            {
                dollHp = 0f;
                FinalProjectGameManager.singleton.hasWon = true;

                OnDollDead?.Invoke();

                GameObject deadParticleGO = Instantiate(onDeadParticle, deadParticlePos.position, Quaternion.identity);

                float particleDestroyTime = 3f;
                Destroy(deadParticleGO, particleDestroyTime);

                Destroy(this.gameObject, .1f);
            }
        }
    }
}
