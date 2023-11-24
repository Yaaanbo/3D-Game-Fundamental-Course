using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAmmo : MonoBehaviour
{
    //Event Action
    public Action<int, int> onAmmoUpdated;
    public Action<int> onLevelUIChanged;

    [Header("Ammo Component")]
    [SerializeField] private int maxAmo;
    private int currentAmo;
    public int CurrentAmmo
    {
        get
        {
            return currentAmo;
        }

        set
        {
            currentAmo = value;
            onAmmoUpdated?.Invoke(currentAmo, maxAmo);
            if(currentAmo <= 0)
            {
                StartCoroutine(OnOutOfAmmo());
            }
        }
    }

    private void Start()
    {
        currentAmo = maxAmo;
        onAmmoUpdated?.Invoke(currentAmo, maxAmo);
    }

    private IEnumerator OnOutOfAmmo()
    {
        float waitTime = 5f;
        yield return new WaitForSeconds(waitTime);
        if(CannonGameManager.instance.brickFallen < CannonGameManager.instance.brickNeeded)
        {
            CannonGameManager.level = 1;
            onLevelUIChanged?.Invoke(CannonGameManager.level);
            CannonGameManager.instance.RestartGame();
            Debug.Log("You Lose");
        }
    }
}
