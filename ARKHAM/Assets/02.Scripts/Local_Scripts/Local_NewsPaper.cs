using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Local_NewsPaper : Local {

    public int activeEvent = 0;


    void Awake()
    {
        local_Id = 02;   //99=아컴지역 004=인접한거리(1번,3번,6번) 02=장소번호
        allowLocal_Id = new int[1];
        allowLocal_Id[0] = 00;

        position = transform.position;
    }

    protected override void EventOne()
    {
        activeEvent = 1;
        eventText = "당신이 흥미로운 이야기를 제공하는 대가로 도일 제프리 편집장이 원고료를 지급합니다. 보유 자산 카드 1장을 얻습니다.";
        Debug.Log("보유자산 획득이벤트 구현");
        //획득만하면 되는 이벤트 구현필요
    }

    protected override void EventTwo()
    {
        activeEvent = 2;
        eventText = "잉크 병에 발이 걸려 넘어졋습니다. 쏟아진 잉크가 만든 패턴을 보고 겁에 질립니다. 정신력 1을 잃습니다.";
        Character.instance.characterSanity -= 1;
    }

    protected override void EventThree()
    {
        activeEvent = 3;
        eventText = "이전 신문을 뒤적거리다가, 당신의 이름으로 시작하는 비밀 광고를 발견하고 깜짝 놀랐습니다. 이를 읽어 보니 아컴을 위협하는 것들에 대한 여러 가지 비밀 암호가 포함되어 있음을 발견할 수 있습니다. 지식 체크(-1)를 합니다. 성공하면 단서 마커 3개를 얻습니다.";
        DiceController.instance.SetDiceThrow(this, (Character.instance.characterLore-1), Character.instance.MinDiceSucc, 6);

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
                break;
            case 2:
                Debug.Log("축복 획득 이벤트 구현");
                ///축복획득 이벤트 구현
                break;
            case 3:
                Debug.Log("마법주문 획득 이벤트");
                //구현해야됨
                if (successCount > 0)
                    Character.instance.clue += 3;
                break;
        }
    }
}
