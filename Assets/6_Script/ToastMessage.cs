using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum ToastType // 메세지 종류 설정
{
    Money,      // 골드 모자랄 때
    Build       // 건설이 불가능 할 때
}
public class ToastMessage : MonoBehaviour
{
    TMP_Text toastMessage;
    TMPAlpha tmpAlpha;
    void Start()
    {
        toastMessage = GetComponent<TMP_Text>();
        tmpAlpha = GetComponent<TMPAlpha>();
    }

    public void ShowToast(ToastType type)
    {
        switch(type)
        {
            case ToastType.Money:
                toastMessage.text = "Not enough money";
                break;
            case ToastType.Build:
                toastMessage.text = "Invalid build tower";
                break;
        }
    }
}
