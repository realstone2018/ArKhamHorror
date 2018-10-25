using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cthulhu : Boss {

    private void Start()
    {
        BossDoomTrack = 13;
        BossCombatRating = -6;
        BossDefense = Defenses.Special;
        BossImage = Resources.Load<Sprite>("StartScenes / Boss /Cthulhu");
        misscombate = "noEvasion";
    }




    public override void Worshippers()   //영향받는 괴물
    {
        Debug.Log("추종자(의지(-2)체크치와 2 정신력 피해를 가진다.)");
        MonsterDictionary.instance.monsterMap["Cultist"].fearLevel = -2;
        MonsterDictionary.instance.monsterMap["Cultist"].sanityDamage = 2;
    }

    public override void BossAbility()   //필드에 영향을 주는 능력
    {
        Debug.Log("최대 정신력과 최대 체력이 1씩 줄어든다.");
        Character.instance.MaxSanity -= 1;
        Character.instance.MaxStamina -= 1;
        Character.instance.characterSanity -= 1;
        Character.instance.characterStamina -= 1;

    }

    public override void StartOfBattle() //보스 전투 시작전 체크
    {
        Debug.Log("없음");
    }

    public override void BossAttack()    //보스 공격
    {
        Debug.Log("각 플레이어는 최대 정신력이나 체력 중 하나를 1 줄인다.또한 크툴루가 공격하고 난 뒤 파멸 트랙이 꽉 차 있지 않다면, 파멸 마커를 1개 다시 놓는다.");
    }
}
