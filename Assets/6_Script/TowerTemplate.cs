using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] // 유니티 에디터 메뉴에 나오게 된다
public class TowerTemplate : ScriptableObject
{
    public GameObject towerPrefab; // 타워 생성을 위한 프리펩
    public Weapon[] weapon; // 레벨 별 타워(무기) 정보

    [System.Serializable] // 직렬화 : 에디터에서 사용하거나 파일로 만들거나
    public struct Weapon
    {
        public Sprite sprite;           // 타워 이미지
        public float damage;            // 공격력
        public float rate;              // 공격 속도
        public float range;             // 공격 범위
        public int cost;                // 필요 골드
        public int sell;                // 판매 골드
    }
}
