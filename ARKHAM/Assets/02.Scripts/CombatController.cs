using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour {

    public Character character;
    public Monster monster;

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
        
        combatCamera.SetActive(true);
        mainCamera.SetActive(false);
    }

    public void EvasionCheck()
    {
        Debug.Log("EvasionCheck : " + character.characterEvadeCheck + "(Character Sneak)  +  " + monster.evasionLevel + "(Monster EvasionLevel)" );

        CombatUI.instance.CombatUIActive(false);

        //character.EvasionCheck(monster.evasionLevel);

        DiceController.instance.SetDice(character.characterEvadeCheck + monster.evasionLevel, Character.instance.MinDiceSucc, 6, DiceController.Use.EvasionCheck);
    }

    public void EvasionCheckResult(int successCount)
    {
        if (successCount > monster.evasionLevel)
        {
            Debug.Log("회피성공");
            FinishCombat();
        }
        else
        {
            Debug.Log("회피체크 실패, " + monster.staminaDamage + "만큼 체력피해를 입습니다");
            character.DamagedStamina(monster.staminaDamage);
            // 전투 or 도망 선택  UI출력   전투버튼클릭시 FearCheck호출,   도망 버튼 클릭시 EvassionCheck호출 

            if (Character.instance.characterState != Character.State.FAINT)
                CombatUI.instance.CombatUIActive(true);
            else
                StartCoroutine(PlayerLose());
        }
    }

    public void FearCheck()
    {
        Debug.Log("FearCheck: " + character.HorrorCheck + "(Character Will)  +  " + monster.fearLevel + "(Monster FearLevel)");

        // UI 변경 
        CombatUI.instance.CombatUIActive(false);

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
        else
            StartCoroutine(PlayerLose());
    }


    public void CombatCheck()
    {
        Debug.Log("CombayCheck: " + character.CombatCheck + "(Character Fight)  +  " + monster.combatLevel + "(Monster combatLevel)");

        // UI변경

        // 물리저항

        // 물리면역

        // 마법저항

        // 마법면역
        DiceController.instance.SetDice(character.CombatCheck + monster.combatLevel, Character.instance.MinDiceSucc, 6, DiceController.Use.CombatCheck);
    }


    public void CombatCheckResult(int successCount)
    {
        if (successCount >= monster.hp)
        {
            Debug.Log("승리");

            StartCoroutine(PlayerWin());  
        }
        else
        {
            Debug.Log("전투체크 실패, " + monster.staminaDamage + "만큼 체력피해를 입습니다");

            character.DamagedStamina(monster.staminaDamage);

            if (Character.instance.characterState != Character.State.FAINT)
                CombatUI.instance.CombatUIActive(true);
            else
                StartCoroutine(PlayerLose());
        }
    }


    private IEnumerator PlayerWin()
    {
        CombatUI.instance.CombatUIActive(false);
        CombatUI.instance.CombatAnimUIActive(true);

        // 몬스터를 플레리어 인벤토리로 이동, 몬스터 컨트롤러 리스트에서 Remove하면서 필드에서 삭제 


        CombatUI.instance.PlayerWinAnim();
        yield return new WaitForSeconds(3.0f);
        FinishCombat();
    }


    private IEnumerator PlayerLose()
    {
        CombatUI.instance.CombatUIActive(false);
        CombatUI.instance.CombatAnimUIActive(true);

        CombatUI.instance.PlayerLoseAnim();
        yield return new WaitForSeconds(3.0f);
        FinishCombat();
    }

    private void FinishCombat()
    {
        Character.instance.CobatComplete();

        combatCamera.SetActive(false);
        mainCamera.SetActive(true);

        // 애니메이션 초기화 
        CombatUI.instance.FinishCombatAnim();

        CombatUI.instance.CombatUIActive(false);
        CombatUI.instance.CombatAnimUIActive(false);
    }
}
