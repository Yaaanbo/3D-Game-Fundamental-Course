using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void Update()
    {
        RestartGame();
    }

    public void OnBrickFall()
    {
        brickFallen++;
        if(brickFallen >= brickNeeded)
        {
            Debug.Log("You Won!");
        }
    }

    private void RestartGame()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
