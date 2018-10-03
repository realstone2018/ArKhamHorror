using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 캐릭터의 상태와 게임 단계에 따라 진행, 한 버튼으로 동작하게 

// 1. 보스 랜덤 선택 후 출력 
// 2. 캐릭터 선택 

    
// 3. 신화 단계 

// 4. 유지 단계 
// 5. 이동 단계
// 6. 조우 단계 
// 7. 신화 단계 
// 8. 순서 4 로 이동 

public class GameManager : MonoBehaviour {

    public enum GameState {Setting,Upkeep, Move, Encounter, Mythos}
    public GameState gameState;
    public int BossBattle=0;

    void Start()
    {
        GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>().Worshippers();    //영향을 끼치는 몬스터
        GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>().BossAbility();    //필드 영향
        gameState = GameState.Setting;
        //RandomBoss();
        SettingSystem.instance.SheetSetting();

    }


    public void DownButton()
    {
        switch(gameState)
        {
            case GameState.Setting:
                GameSetting();
                break;
            case GameState.Upkeep:
                MoveState();
                break;
            case GameState.Move:
                EncounterState();
                break;
            case GameState.Encounter:
                MythosState();
                break;
            case GameState.Mythos:
                UpkeepState();
                break;
        }
    }



    public void RandomBoss()
    {
        Debug.Log("Boss Random Choice");

        // 랜덤 선택 후 출력 그 다음에 자동으로 캐릭터 선택 단계로
        ChoiceCharacter();
    }


    public void ChoiceCharacter()
    {
        Debug.Log("Character Choice Complete");
        // 캐릭터 선택 완료 후 

        // 처음 신화는 소문이 아닌 카드를 뽑을 때 까지 Draw()
        MythosController.instance.FirstMythos();
    }

    public void GameSetting()
    {
        gameState = GameState.Mythos;
        SettingSystem.instance.EndSetting();

    }



    public void UpkeepState()
    { 
        MythosController.instance.MythosStateEnd();
   
        gameState = GameState.Upkeep;

        UpkeepButtonEvent.instance.UpkeepEnCounterStep();
    }


    public void MoveState()
    {
        gameState = GameState.Move;

        UpkeepButtonEvent.instance.UpkeepStepEnd();

        // 이동 단계 UI 결정되면 출력함수 호출
    }


    public void EncounterState()
    {
        // 이동 단계 UI 비활성화 함수 호출  

        gameState = GameState.Encounter;

        LocalEventController.instance.LocalEnCounterStep();
       
        
    }


    public void MythosState()
    {
        //이벤트 화면 비활성화 홈수
        //LocalEventController.instance.ExitEvent();
        
        gameState = GameState.Mythos;

        MythosController.instance.MythosStep();

    }

}
