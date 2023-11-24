using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CannonGameManager : MonoBehaviour
{
    public static CannonGameManager instance;

    public Action<int> onLevelUIChanged;
    public Action onSetAmmo;
    public int brickFallen { get; private set; }
    public int brickNeeded { get; set; }

    [Header("Components")]
    [SerializeField] private GameObject[] wallPrefabs;
    [SerializeField] private Transform wallSpawnPos;

    public static int level = 1;

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
        onLevelUIChanged?.Invoke(level);
    }

    public void OnBrickFall()
    {
        brickFallen++;
        if(brickFallen >= brickNeeded)
        {
            level++;
            onLevelUIChanged?.Invoke(level);
            RestartGame();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void SpawnWall()
    {
        int randomWall = UnityEngine.Random.Range(0, wallPrefabs.Length);
        Instantiate(wallPrefabs[randomWall], wallSpawnPos.position, Quaternion.identity);
    }
}
