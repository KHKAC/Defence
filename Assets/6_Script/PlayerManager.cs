using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance; // 싱글톤 인스턴스
    [SerializeField] float maxHP = 20.0f; // 최대 체력
    [SerializeField] int currentGold = 100; // 현재 골드
    [SerializeField] Image imageRed;
    [SerializeField] GameObject gameOverUI; // 게임 오버 표시하는 UI
    float currentHP; // 현재 체력

    public float MaxHP => maxHP; // 최대 체력 Property
    public float CurrentHP => currentHP; // 현재 체력 Property
    public int CurrentGold
    {
        get => currentGold;
        // 음수로 만드는 경우를 대비
        set => currentGold = Mathf.Max(0, value);
    }

    void Awake()
    {
        if(Instance == null) Instance = this;
    }
    
    void Start()
    {
        // 현재 체력을 최대 체력으로 초기화
        currentHP = maxHP;
        // 게임 오버 UI는 끄고 시작
        gameOverUI.SetActive(false);
    }

    public void TakeDamage(float damage)
    {
        // 데미지의 양 만큼 체력을 감소시키고
        currentHP -= damage;
        // 돌아가는 코루틴이 있다면 멈추고
        StopCoroutine(HitAlphaAnimation());
        // 체력이 0이하가 되면
        if(currentHP <= 0)
        {
            // 게임 오버 표시
            gameOverUI.SetActive(true);
            // 화면 깜빡임 도중에 시간이 멈추는 것을 방지 -> 알파값
            Color color = imageRed.color;
            color.a = 0;
            imageRed.color = color;
            // 게임의 시간을 멈춰서 게임 진행이 안 되게 한다.
            Time.timeScale = 0f;
        }
        else
        {
            // 화면 깜빡이는 코루틴 실행
            StartCoroutine(HitAlphaAnimation());
        }
    }

    IEnumerator HitAlphaAnimation()
    {
        // 이미지의 color 값을 얻어와서
        Color color = imageRed.color;
        // 알파값만 40%로 설정
        color.a = 0.4f;
        imageRed.color = color;
        // 알파값이 0이상이면
        while (color.a >= 0f)
        {
            // 조금씩 알파값을 감소시킨다.
            color.a -= Time.deltaTime;
            imageRed.color = color;
            // 코루틴 반복
            yield return null;
        }
    }
}
