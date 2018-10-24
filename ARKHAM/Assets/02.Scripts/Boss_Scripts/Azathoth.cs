using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Azathoth : Boss {

    private void Start()
    {
        BossDoomTrack = 14;
        BossCombatRating = -999999;
        BossDefense = Defenses.None;
    }

    


    public override void Worshippers()   //영향받는 괴물
    {
        Debug.Log("광인 체력 +1");
    }

    public override void BossAbility()   //필드에 영향을 주는 능력
    {
        Debug.Log("파멸트랙이 다차면 게임 패배");
    }

    public override void StartOfBattle() //보스 전투 시작전 체크
    {
        Debug.Log("없음");
    }

    public override void BossAttack()    //보스 공격
    {
        Debug.Log("없음");
    }
    
}
