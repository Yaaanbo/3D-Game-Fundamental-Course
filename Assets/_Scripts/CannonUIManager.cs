using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CannonUIManager : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private CannonAmmo cannonAmmo;

    [Header("Cannon Ammo UI")]
    [SerializeField] private TMP_Text ammoText;

    private void OnEnable()
    {
        cannonAmmo.onAmmoUpdated += (int _currentAmmo, int _maxAmmo) =>
        {
            ammoText.text = $"Ammo : {_currentAmmo} / {_maxAmmo}";
        };
    }

    private void OnDisable()
    {
        cannonAmmo.onAmmoUpdated -= (int _currentAmmo, int _maxAmmo) =>
        {
            ammoText.text = $"Ammo : {_currentAmmo} / {_maxAmmo}";
        };
    }
}
