using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    public int BossDoomTrack;   //파멸트랙
    public int BossCombatRating;    //주사위 수정치
    public enum Defenses { Special, None, PhysicalResistance, MagicalResistance, PhysicallImmunity, MagicalImmunity };
    public Defenses BossDefense;    //방어수단 
    public int CombatCheck;
    public Sprite BossImage;
    public string misscombate;

    public static Boss instance = null;

    /*public Boss(int _BossDoomTrack, int _BossCombatRating, Defenses _BossDefense)
    {
        BossDoomTrack = _BossDoomTrack;
        BossCombatRating = _BossCombatRating;
        BossDefense = _BossDefense;

    }*/


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public virtual void Worshippers()   //영향받는 괴물
    {

    }

    public virtual void BossAbility()   //필드에 영향을 주는 능력
    {

    }

    public virtual void StartOfBattle() //보스 전투 시작전 체크
    {

    }

    public virtual void BossAttack()    //보스 공격
    {

    }

    public virtual void DamegeResult(int success)
    {

    }
    public virtual void BossDieCheck()
    {
        if(BossDoomTrack<0)
        {
            //게임 정산화면
            Destroy(this.gameObject);
            
        }
    }

}
