using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTarget;
    [SerializeField] private float camSpeed;
    [SerializeField] private Vector3 camOffset;

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, playerTarget.position + camOffset, camSpeed * Time.deltaTime);
    }
}
