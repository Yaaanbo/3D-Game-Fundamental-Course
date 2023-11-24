using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CannonUIManager : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private CannonAmmo cannonAmmo;
    [SerializeField] private CannonGameManager cannonManager;

    [Header("Cannon Ammo UI")]
    [SerializeField] private TMP_Text ammoText;

    [Header("Level UI")]
    [SerializeField] private TMP_Text levelText;

    private void OnEnable()
    {
        cannonAmmo.onAmmoUpdated += (int _currentAmmo, int _maxAmmo) => { ammoText.text = $"Ammo : {_currentAmmo} / {_maxAmmo}"; };
        cannonAmmo.onLevelUIChanged += (int _level) => { levelText.text = "Level : " + _level; };
        cannonManager.onLevelUIChanged += (int _level) => { levelText.text = "Level : " + _level; };
    }

    private void OnDisable()
    {
        cannonAmmo.onAmmoUpdated -= (int _currentAmmo, int _maxAmmo) => { ammoText.text = $"Ammo : {_currentAmmo} / {_maxAmmo}"; };
        cannonAmmo.onLevelUIChanged -= (int _level) => { levelText.text = "Level : " + _level; };
        cannonManager.onLevelUIChanged -= (int _level) => { levelText.text = "Level : " + _level; };
    }
}
