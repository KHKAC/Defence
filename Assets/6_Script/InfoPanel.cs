using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] TMP_Text textPlayerHP; // 유저 체력
    [SerializeField] TMP_Text textGold; // 골드
    [SerializeField] TMP_Text textWave;
    [SerializeField] TMP_Text textEnemy;
    [SerializeField] WaveSystem waveSystem;

    void Update()
    {
        PlayerManager pmi = PlayerManager.Instance;
        // 체력 표시
        textPlayerHP.text = $"{pmi.CurrentHP} / {pmi.MaxHP}";
        // 골드 표시
        textGold.text = $"{pmi.CurrentGold}";
        // 웨이브 표시
        textWave.text = waveSystem.GetWaveInfoString();
        // 적 수 표시
        EnemyManager emi = EnemyManager.Instance;
        textEnemy.text = $"{emi.CurrentEnemyCount} / {emi.MaxEnemyCnt}";
    }
}
