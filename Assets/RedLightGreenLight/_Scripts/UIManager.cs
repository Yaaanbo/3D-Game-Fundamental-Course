using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerController player;

    [Header("UIs")]
    [SerializeField] private TMP_Text youWonText;

    private void OnEnable()
    {
        player.OnPlayerWon += () => { youWonText.gameObject.SetActive(true); };
    }

    private void OnDisable()
    {
        player.OnPlayerWon -= () => { youWonText.gameObject.SetActive(true); };
    }
}
