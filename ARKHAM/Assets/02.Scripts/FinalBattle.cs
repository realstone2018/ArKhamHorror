using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBattle : MonoBehaviour {

    public int DoomTrack;
    public int MonsterNum;

    public static FinalBattle instance = null;

    private void Awake()
    {
        DoomTrack = 0;
        MonsterNum = 0;

        instance = this;
    }

    public void CheckDoomTrack(int BossDoomtrack)   //보스 전투 조건 체크
    {
        //아자토스 보스 전투 안함
        if (GameObject.FindGameObjectWithTag("Boss").ToString() == "Boss_Azathoth(Clone) (UnityEngine.GameObject)")
        {
            Debug.Log("게임 끝");
        }

        else if (DoomTrack == BossDoomtrack)
        {
            //GameObject.FindGameObjectWithTag("Boss").ToString();
            Debug.Log("마지막 전투 패널 활성화 나머지 비활성화");
        }
    }
}
