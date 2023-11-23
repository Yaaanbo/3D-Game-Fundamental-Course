using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksBehaviour : MonoBehaviour
{
    private const string FALLEN_WALL_DETECTOR_TAG = "FallenWallDetector";
    private bool isFallen;

    private void OnTriggerEnter(Collider other)
    {
        if (isFallen) return;

        if (other.CompareTag(FALLEN_WALL_DETECTOR_TAG))
        {
            isFallen = true;
            CannonGameManager.instance.OnBrickFall();
        }
    }
}
