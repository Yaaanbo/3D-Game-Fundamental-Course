using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinalProjectUIManager : MonoBehaviour
{
    [Header("Class Reference")]
    [SerializeField] private FinalProjectDollController doll;
    [SerializeField] private FinalProjectPlayerController player;

    [Header("UIs")]
    [SerializeField] private Image healthBarFill;
    [SerializeField] private TMP_Text stageText;

    private void OnEnable()
    {
        doll.OnDollHit += (float _currentDollHp, float _dollMaxHp) => { healthBarFill.fillAmount = _currentDollHp / _dollMaxHp; };
        doll.OnDollDead += () => { stageText.text = "YOU WON!"; };
    }

    private void OnDisable()
    {
        doll.OnDollHit -= (float _currentDollHp, float _dollMaxHp) => { healthBarFill.fillAmount = _currentDollHp / _dollMaxHp; };
        doll.OnDollDead -= () => { stageText.text = "YOU WON!"; };
    }
}
