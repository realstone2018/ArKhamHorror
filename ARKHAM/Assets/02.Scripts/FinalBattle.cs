using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBattle : MonoBehaviour {

    public int DoomTrack;
    public int MonsterNum;

    public GameObject FinalBattleCanvas;
    public GameObject FinalBattlePanel;
    public GameObject OtherPanel;


    public enum BattlePhase { UpKeep,CharacterPhaseSelect, CharacterAttack, BossPhase }
    public BattlePhase phase = BattlePhase.UpKeep;

    public static FinalBattle instance = null;

    private void Awake()
    {
        DoomTrack = 0;
        MonsterNum = 0;

        instance = this;
    }

    public void CheckDoomTrack(int BossDoomtrack)   //보스 전투 조건 체크
    { 

        if (DoomTrack == BossDoomtrack)
        {
            //아자토스 보스 전투 안함

            Debug.Log(GameObject.FindGameObjectWithTag("Boss").ToString());
            if (GameObject.FindGameObjectWithTag("Boss").ToString() == "Boss_Azathoth(Clone) (UnityEngine.GameObject)")
            {
                Debug.Log("게임 끝");
                return;
            }
            //GameObject.FindGameObjectWithTag("Boss").ToString();
            Debug.Log("마지막 전투 패널 활성화 나머지 비활성화");
            OtherPanel.SetActive(false);
            Boss.instance.StartOfBattle();
            FinalBattleCanvas.SetActive(true);
        }
    }
    
    public void BossAttack()
    {
        GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>().BossAttack();
    }

    public void FinalBattlePhase()
    {
        switch (phase)
        {
            case BattlePhase.UpKeep:
                Debug.Log("CharacterPhase");
                CharacterPhase();
                break;
            case BattlePhase.CharacterPhaseSelect:
                Debug.Log("CharacterAttack");
                CharacterAttack();
                break;
            case BattlePhase.CharacterAttack:
                Debug.Log("BossPhase");
                BossPhase();
                break;
            case BattlePhase.BossPhase:
                Debug.Log("UpKeep");
                UpKeep();
                break;
           
        }
    }

    public void UpKeep()
    {
        Debug.Log("업킵단계");
        UpkeepButtonEvent.instance.UpkeepEnCounterStep();
        phase = BattlePhase.UpKeep;

    }

    public void CharacterPhase()
    {
        Debug.Log("캐릭터 전투");
        UpkeepButtonEvent.instance.UpkeepStepEnd();
        FinalBattlePanel.SetActive(true);
        UpkeepButtonEvent.instance.ShowInventory();
        phase = BattlePhase.CharacterPhaseSelect;
    }

    public void CharacterAttack()
    {
        Debug.Log("캐릭터 공격");
        FinalBattlePanel.SetActive(false);

        Debug.Log(Character.instance.CombatCheck + Boss.instance.BossCombatRating);
        DiceController.instance.SetDice(Character.instance.CombatCheck+Boss.instance.BossCombatRating,Character.instance.MinDiceSucc,6,DiceController.Use.FinalBattle);
        phase = BattlePhase.CharacterAttack;
    }

    public void BossPhase()
    {
        Debug.Log("보스전투");
        Boss.instance.BossAttack();
        phase = BattlePhase.BossPhase;
    }

    public void AttackResult(int succ)
    {
        Debug.Log("보스 데미지 : "+succ);
        Boss.instance.BossDoomTrack -= succ;
        Debug.Log("남은 보스 체력 : "+ Boss.instance.BossDoomTrack);
    }


}
