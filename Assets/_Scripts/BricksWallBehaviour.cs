using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksWallBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CannonGameManager.instance.brickNeeded += this.transform.childCount;
    }
}
