using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBattle : MonoBehaviour {

    public int doomTrack;
    public int monsterNum;
    public int bossDoomtrack;

    public static FinalBattle instance = null;
    

    private void Awake()
    {
        doomTrack = 0;
        monsterNum = 0;

        instance = this;
    }


    public void DoomTrackCheck()
    {
        doomTrack += 1;

        bossDoomtrack = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>().BossDoomTrack;

        if (doomTrack == bossDoomtrack)
        {
            //아자토스 보스 전투 안함
            if (GameObject.FindGameObjectWithTag("Boss").ToString() == "Boss_Azathoth(Clone) (UnityEngine.GameObject)")
            {
                Debug.Log("게임 끝");
            }
            //GameObject.FindGameObjectWithTag("Boss").ToString();
            Debug.Log("마지막 전투 패널 활성화 나머지 비활성화");
        }
    }

}
