using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] TMP_Text playerHpTxt;
    [SerializeField] TMP_Text playerGoldTxt;
    
    void Update()
    {
        // 체력을 표시
        playerHpTxt.text = $"{PlayerManager.Instance.CurrentHP} / {PlayerManager.Instance.MaxHP}";
        // 골드 표시
        playerGoldTxt.text = $"{PlayerManager.Instance.CurrentGold}";
    }
}
