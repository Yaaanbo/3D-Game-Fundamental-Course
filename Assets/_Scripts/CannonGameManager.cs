using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CannonGameManager : MonoBehaviour
{
    public static CannonGameManager instance;

    public int brickFallen { get; private set; }
    public int brickNeeded { get; set; }

    [Header("Components")]
    [SerializeField] private GameObject[] wallPrefabs;
    [SerializeField] private Transform wallSpawnPos;

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
        SpawnWall();
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

    private void SpawnWall()
    {
        int randomWall = Random.Range(0, wallPrefabs.Length);
        Instantiate(wallPrefabs[randomWall], wallSpawnPos.position, Quaternion.identity);
    }
}
