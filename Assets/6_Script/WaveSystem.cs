using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 유니티 에디터에서 사용하거나 파일로 저장하기 위해서 Serialize 필요
[System.Serializable]
public struct Wave
{
    [Tooltip("적 생성 주기 : 작을 수록 적이 빠르게 생성")]
    public float spawnTime;             // 적의 생성 주기
    [Tooltip("적 최대 수 : 이번 웨이브에 나오는 적의 수")]
    public int maxEnemyCnt;             // 적의 최대 숫자
    public GameObject[] enemyPrefabs;   // 적의 종류
}

public class WaveSystem : MonoBehaviour
{
    [SerializeField] Wave[] waves; // 웨이브 정보 배열
    int currentWaveIdx = -1; // 현재 웨이브 인덱스 (0에서 시작해야해서 시작값 -1)
    
    // 현재 인덱스에 해당하는 웨이브 실행
    public void StartWave()
    {
        // 적이 없고 웨이브가 남아있다면 가능
        if((EnemyManager.Instance.EnemyList.Count == 0) && (currentWaveIdx < waves.Length -1))
        {
            // 웨이브 인덱스 하나 증가
            currentWaveIdx++;
            // 현재 인덱스에 해당하는 웨이브 실행
            EnemyManager.Instance.StartWave(waves[currentWaveIdx]);
        }
    }

    // [현재 웨이브 / 총 웨이브] 문자열 얻어오기
    public string GetWaveInfoString()
    {
        return $"{currentWaveIdx + 1} / {waves.Length}";
    }
}
