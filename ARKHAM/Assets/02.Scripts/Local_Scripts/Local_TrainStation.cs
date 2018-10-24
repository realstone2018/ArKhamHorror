using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Local_TrainStation : Local {
    public int activeEvent;

    void Awake()
    {
        
        local_Id = 03;   //99=아컴지역 004=인접한거리(1번,3번,6번) 02=장소번호
        allowLocal_Id = new int[1];
        allowLocal_Id[0] = 00;

        position = transform.position;
    }

    protected override void EventOne()
    {
        activeEvent = 1;
        eventText = "조이 비질이 기차 그림자 속에 쭈그리고 앉아서 당신을 향해 자기에게 오라고 손짓합니다. 다가가니 그가 무언가 팔 물건이 있다고 합니다. 일반 아이템 카드 1장을 뽑고 액면가보다 1$을 더 내고 살 수 있습니다.";
        EventResult(0);


    }

    protected override void EventTwo()
    {
        activeEvent = 2;
        eventText = "보스턴발 열차에서 터번을 둘러쓰고 얼굴에서 광기가 엄치는 한 사람이 내렸습니다. 행운 체크(-1)를 합니다. 성공하면 그가 망토 속에서 기이한 물건 하나를 꺼내 당신에게 건네줍니다. 특별 아이템 카드 1장을 얻습니다. 실패하면 그는 갑자기 망토 속에서 독을 바른 칼날을 꺼내 당신을 찌릅니다. 주사위 1개를 굴려 나온 값만큼 체력을 잃습니다.";
        DiceController.instance.SetDiceThrow(this, (Character.instance.characterLuck - 1), Character.instance.MinDiceSucc, 6);


    }

    protected override void EventThree()
    {
        activeEvent = 3;
        eventText = "빌 워싱턴이 짐수레에서 마지막 짐을 트럭으로 옮기고 있습니다. 운전석의 문을 열며 당신에게 차를 태워줄까 묻습니다. 이에 응하면, 아컴에서 원하는 장소나 거리로 이동합니다. 이동한 곳에 해당하는 장소카드를 뽑아 그 지시에 따릅니다.";

        Debug.Log("선택이 가능한 이벤트이며 해당장소에서의 조우 구현");
        //조우 구현 요망
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
                Debug.Log("아이템 구입 이벤트 발생  잡화점 고정 능력과 함께 구현");

                LocalEventController.instance.LocalBuyEventButtonDown(11);
                break;
                //잡화점에서 구매 이벤트에 가격을 +1해서 살수있는 이벤트
            case 2:
                if (successCount == 0)
                {
                    DiceController.instance.AdditoryDiceValue = true;

                    DiceController.instance.SetDiceThrow(this, 1, 1, 6);

                    Character.instance.DamagedStamina(DiceController.instance.ResultDiceValue());
                    //주사위랑 결과부분 분리 요망
                    //주사위에서 결과를 호출해서 주사위가 계속 반복됨
                    //주사위 굴려서 나온 숫자만큼 체력 감소
                }
                else if (successCount > 0)
                {
                    ItemDictionary.instance.DrowOneCard(2);//특별아이템 획득이벤트
                    
                }


                break;
            case 3:
                Debug.Log("마법주문 획득 이벤트");
                //구현해야됨
                if (successCount == 0)
                {
                    Debug.Log("아이템 선택후 버리는 이벤트");
                    //아이템 선택후 버려야하는 이벤트
                }

                break;
        }
    }

}
