using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Local_CuriositleS : Local {
    public int activeEvent = 0;


    void Awake () {
        local_Id = 01;   //99=아컴지역 004=인접한거리(1번,3번,6번) 00=장소번호
        allowLocal_Id = new int[1];
        allowLocal_Id[0] = 00;

        position = transform.position;
        localFunction = "특별카드 3장을 뽑고 원하는 카드는 금액을 지불하고 구입가능하다";
    }


    protected override void EventOne()
    {
        activeEvent = 1;
        eventText = "행운 체크(-1)를 합니다. 실패하면 소지품을 잃어버립니다. 아이템 카드 중 1장을 버립니다. 만약 버릴 아이템카드가 없다면 새로운 장소 카드를 뽑아 그 지시에 따릅니다.";
        DiceController.instance.SetDiceThrow(this, (Character.instance.characterLuck-1), Character.instance.MinDiceSucc, 6);

    }

    protected override void EventTwo()
    {
        activeEvent = 2;
        eventText = "상점 뒤쪽을 어슬렁거리는 중에 뭔가 소음이 들립니다. 속도 체크(-1)를 합니다. 실패하면 당신을 가격하는 몽둥이를 볼 수 있습니다. 눈앞이 캄캄해집니다. 당신이 일어났을 때 다른 곳에 있음을 발견합니다. 신화 카드 1장을 뽑고 카드의 왼쪽아래에 있는 차원문이 발생하는 곳으로 이동합니다. 이곳에서 장소 카드를 뽑아 그 지시를 따릅니다.";
        DiceController.instance.SetDiceThrow(this, (Character.instance.characterSpeed - 1), Character.instance.MinDiceSucc, 6);


    }

    protected override void EventThree()
    {
        activeEvent = 3;
        eventText = "일반아이템카드 3장과 특별아이템카드 1장을 뽑아 액면가에 살수있습니다.";

        Debug.Log("일반아이템 3개와 특별아이템 1개중에 원하는것을 구입하는 이벤트");
        //남은카드는 버리며 원하는만큼 살수있음
    }

    protected override void EventFour()
    {

    }

    protected override void EventFive()
    {

    }

    protected override void EventSiz()
    {

    }

    protected override void EventSeven()
    {

    }

    public override void EventResult(int _successCount)
    {
        int successCount = _successCount;


        switch (activeEvent)
        {
            case 1:
                if (successCount == 0)
                {
                    Debug.Log("아이템을 하나 선택하여 버리는 이벤트");
                    Debug.Log("버릴 아이템이 없을경우 다시 뽑는 이벤트 발생");
                    //구현 필요
                }
                
                break;
            case 2:
                if (successCount == 0)
                {
                    Debug.Log("신화카드 한장 확인후 지정된 장소로 이동");
                    Debug.Log("이동한 장소에서 다시 이벤트 발생");
                    //구현 필요
                }
                break;
            case 3:
                
                break;
        }
    }


}
