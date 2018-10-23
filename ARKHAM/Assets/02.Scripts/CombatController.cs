using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatController : MonoBehaviour {

    public Character character;
    public Monster monster;

    public GameObject CombatPanel;
    public GameObject mainCamera;
    public GameObject combatCamera;

    public static CombatController instance = null;

    private void Awake()
    {
        instance = this;
    }

    public  void SetCombatController(Character _character, Monster _monster)
    {
        character = _character;
        monster = _monster;

        // CobatUIPanel 변경 후 호출 
        CombatUI.instance.SetCombatUI(monster.id);

        
        CombatPanel.SetActive(true);

        combatCamera.SetActive(true);
        mainCamera.SetActive(false);
    }

    public void EvasionCheck()
    {
        Debug.Log("EvasionCheck : " + character.EvadeCheck + "(Character Sneak)  +  " + monster.evasionLevel + "(Monster EvasionLevel)" );

        CombatPanel.SetActive(false);

        //character.EvasionCheck(monster.evasionLevel);

        DiceController.instance.SetDice(character.EvadeCheck + monster.evasionLevel, Character.instance.MinDiceSucc, 6, DiceController.Use.EvasionCheck);
    }

    public void EvassionCheckResult(int successCount)
    {

        if (successCount > 0)
        {
            Debug.Log("회피성공");
            // 회피
        }
        else
        {
            Debug.Log("회피체크 실패, " + monster.staminaDamage + "만큼 체력피해를 입습니다");
            character.DamagedStamina(monster.staminaDamage);
            // 전투 or 도망 선택  UI출력   전투버튼클릭시 FearCheck호출,   도망 버튼 클릭시 EvassionCheck호출 

            if (Character.instance.characterState != Character.State.FAINT)
                CombatPanel.SetActive(true);
        }
    }

    public void FearCheck()
    {
        Debug.Log("FearCheck: " + character.HorrorCheck + "(Character Will)  +  " + monster.fearLevel + "(Monster FearLevel)");

        // UI 변경 
        CombatPanel.SetActive(false);

        DiceController.instance.SetDice(character.HorrorCheck + monster.fearLevel, Character.instance.MinDiceSucc, 6, DiceController.Use.FearCheck);     
    }

    public void FearCheckResult(int successCount)
    {
        if (successCount == 0)
        {
            Debug.Log("공포체크 실패, " + monster.sanityDamage + "만큼 정신피해를 입습니다");
            character.DamagedSanity(monster.sanityDamage);
        }
        else
            Debug.Log("공포체크 성공 ");

        if (Character.instance.characterState != Character.State.FAINT)
            CombatCheck();
    }

    public void CombatCheck()
    {
        Debug.Log("CombayCheck: " + character.CombatCheck + "(Character Fight)  +  " + monster.combatLevel + "(Monster combatLevel)");

        // UI변경

        DiceController.instance.SetDice(character.CombatCheck + monster.combatLevel, Character.instance.MinDiceSucc, 6, DiceController.Use.CombatCheck);
    }

    public void CombatCheckResult(int successCount)
    {
        if (successCount >= monster.hp)
        {
            Debug.Log("승리");

            // 일단 임시적으로 직접참조
            Character.instance.CobatComplete();

            // 캐릭터 인벤에 트로피로
            Destroy(monster.gameObject);
            
            //전투종료 UI변경
        }
        else
        {
            Debug.Log("전투체크 실패, " + monster.staminaDamage + "만큼 체력피해를 입습니다");

            character.DamagedStamina(monster.staminaDamage);
            // 도망 or 전투 UI 출력

            if (Character.instance.characterState != Character.State.FAINT)
                CombatPanel.SetActive(true);

        }
    }

}
