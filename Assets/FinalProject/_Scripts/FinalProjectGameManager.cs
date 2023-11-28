using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalProjectGameManager : MonoBehaviour
{
    public static FinalProjectGameManager singleton;

    public bool hasWon { get; set; }

    private void Awake()
    {
        if(singleton == null)
        {
            singleton = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(singleton);
        }
    }

    public IEnumerator RestartGame()
    {
        float waitTime = 3f;
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
