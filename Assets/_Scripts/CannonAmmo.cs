using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAmmo : MonoBehaviour
{
    public Action<int, int> onAmmoUpdated;

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
        }
    }

    private void Start()
    {
        currentAmo = maxAmo;
        onAmmoUpdated?.Invoke(currentAmo, maxAmo);
    }
}
