using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonGameManager : MonoBehaviour
{
    public static CannonGameManager instance;

    public int brickFallen { get; private set; }
    public int brickNeeded { get; private set; }

    [Header("Components")]
    [SerializeField] private Transform brickParent;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        brickNeeded = brickParent.childCount;
    }

    public void OnBrickFall()
    {
        brickFallen++;
        if(brickFallen >= brickNeeded)
        {
            Debug.Log("You Won!");
        }
    }
}
