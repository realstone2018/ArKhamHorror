using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHP : MonoBehaviour {

    private Text bossHP;
    private void Start()
    {
        bossHP = GetComponent<Text>();
        bossHP.text = Boss.instance.BossDoomTrack.ToString();
    }
    void Update () {
        if (FinalBattle.instance.phase==FinalBattle.BattlePhase.UpKeep)
        {
            bossHP.text = Boss.instance.BossDoomTrack.ToString();
        }
	}
}
