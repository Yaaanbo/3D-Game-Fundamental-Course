using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GlassBridgeUIManager : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private GlassBridgePlayerController player;

    [Header("UIs")]
    [SerializeField] private TMP_Text wonText;

    private void OnEnable()
    {
        player.OnPlayerWon += () => { wonText.gameObject.SetActive(true); };
    }

    private void OnDisable()
    {
        player.OnPlayerWon -= () => { wonText.gameObject.SetActive(true); };
    }
}
