using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yig : Boss {

    private void Start()
    {
        BossDoomTrack = 10;
        BossCombatRating = -3;
        BossDefense = Defenses.None;
        CombatCheck = +1;
        BossImage = Resources.Load<Sprite>("StartScenes / Boss / Yig");
    }




    public override void Worshippers()   //영향받는 괴물
    {
        Debug.Log("추종자(전투(+0)체력치, 4 체력 피해를 가진다))");
        MonsterDictionary.instance.monsterMap["Cultist"].combatLevel = 0;
        MonsterDictionary.instance.monsterMap["Cultist"].staminaDamage = 4;
    }

    public override void BossAbility()   //필드에 영향을 주는 능력
    {
        Debug.Log("추종자가 패하거나, 조사자들이 시공의 저편에 갈 때마다 파멸 마커를 추가한다.");
        FinalBattle.instance.DoomTrack += 1;
        //호출 위치 지정
        
    }

    public override void StartOfBattle() //보스 전투 시작전 체크
    {
        Debug.Log("저주가 적용됨(이미 저주 받았을 경우 먹힘)");
        Character.instance.MinDiceSucc += 1;
        if(Character.instance.MinDiceSucc>6)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
    }

    public override void BossAttack()    //보스 공격
    {
        //int Checknum;
        Debug.Log("공격 시 속도(+1)체크를 통과할 것. 실패시 체력 1과 정신력 1을 잃는다. 이 체크 수정치는 매 턴마다 1씩 감소한다.");
        DiceController.instance.SetDiceThrowBoss((Character.instance.characterSpeed + CombatCheck), Character.instance.MinDiceSucc, 6);
        
    }

    public override void DamegeResult(int success)
    {
        int suc = success;
        if(1>suc)
        {
            Debug.Log("통과");
        }
        else
        {
            Debug.Log("데미지");
            Character.instance.characterStamina -= 1;
            Character.instance.characterSanity -= 1;

            if(Character.instance.characterSanity<0 || Character.instance.characterStamina < 0)
            {
                Destroy(GameObject.FindGameObjectWithTag("Player"));
                Debug.Log("게임끝");
                //게임 앤드 화면
            }
        }
        CombatCheck -= 1;
        Debug.Log("수정치 : " + CombatCheck);
    }

}
