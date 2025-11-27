using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoTower : MonoBehaviour
{
    [SerializeField] Image imageTower;                  // 타워 이미지
    [SerializeField] TMP_Text textLevel;                // 타워 레벨
    [SerializeField] TMP_Text textDamage;               // 타워 공격력
    [SerializeField] TMP_Text textRate;                 // 타워 공격 속도
    [SerializeField] TMP_Text textRange;                // 타워 공격 범위
    [SerializeField] TowerAttackRange towerAttackRange; // 공격 범위 표시
    [SerializeField] TMP_Text textBtnUpgrade;           // 업그레이드 비용
    [SerializeField] Button btnUpgrade;                 // 업그레이드 버튼
    [SerializeField] ToastMessage toastMessage;
    TowerWeapon currentTower;

    void Start()
    {
        // 시작했을 때는 패널이 꺼져 있어야 한다
        OffPanel();
    }

    void Update()
    {
        // esc키가 눌리면 패널을 끄자
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OffPanel();
        }
    }

    public void OnPanel(Transform towerWeapon)
    {
        currentTower = towerWeapon.GetComponent<TowerWeapon>();
        gameObject.SetActive(true);
        UpdateTowerData();
        // 공격범위 이미지 켜기
        towerAttackRange.OnAttackRange(
            currentTower.transform.position,
            currentTower.Range);
    }

    public void OffPanel()
    {
        gameObject.SetActive(false);
        // 공격범위 이미지 끄기
        towerAttackRange.OffAttackRange();
    }

    void UpdateTowerData()
    {
        // 타워 정보 표시
        imageTower.sprite = currentTower.TowerSprite;
        textLevel.text = $"Level : {currentTower.Level}";
        textDamage.text = $"Damage : {currentTower.Damage}";
        textRate.text = $"Rate : {currentTower.Rate}";
        textRange.text = $"Range : {currentTower.Range}";
        textBtnUpgrade.text = $"Up : {currentTower.CostUpgrade}";

        // 더 이상 업그레이드가 불가능하면 버튼 안 눌리게 처기(상호작용(interactable) 안 되게)
        btnUpgrade.interactable = currentTower.Level < currentTower.MaxLevel ? true : false;
    }

    public void OnClickTowerUpgrade()
    {
        // 업그레이드가 성공하면
        if(currentTower.Upgrade())
        {
            // 데이터를 갱신하고
            UpdateTowerData();
            // 공격범위 표시 갱신
            towerAttackRange.OnAttackRange(currentTower.transform.position, currentTower.Range);
        }
        else
        {
            // 안 된다고 메세지 표시
            toastMessage.ShowToast(ToastType.Money);
        }
    }
}
