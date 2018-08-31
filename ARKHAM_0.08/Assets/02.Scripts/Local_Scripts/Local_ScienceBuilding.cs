using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Local_ScienceBuilding : Local {

    public int activeEvent = 0;

    void Start()
    {
        local_Id = 9900411;   //99=아컴지역 004=인접한거리(1번,3번,6번) 10=장소번호
        allowLocal_Id = new int[1];
        allowLocal_Id[0] = 9913694;

        position = transform.position;

        localFunction = "2$를 지불하고 생명력을 모두 회복 가능 합니다.";
    }


    protected override void EventOne()
    {
        activeEvent = 1;

        eventText = "분젠 버너 근처에서 화학물질이 거품을 내고 있습니다. 여기서 맛있는 냄새가 납니다. 이를 마시기로 하면 행운 체크(+0)를 합니다. 성공하면 이 수상한 액체가 신체에 활력을 불어넣습니다. 주사위 1개를 굴려 나온 값만큼 체력과 정신력을 원하는 대로 회복합니다. 실패하면 이 액체는 보통 커피입니다. 체력을 1 회복합니다.";


        DiceController.instance.SetDiceThrow(this, (Character.instance.characterLuck), Character.instance.MinDiceSucc, 6);
    }

    protected override void EventTwo()
    {
        activeEvent = 2;

        eventText = "화학과 연구실에 들어가보니 한 교수가 공포에 질려 있었습니다. 그는 고대의 인공물을 잠겨 있던 책상 서랍에서 써내 들고는 이를 당신의 얼굴로 내밀었습니다. 그리고는 알 수 없는 몸동작과 함께 주문을 외웟습니다. 저주 받은 상태라면 저주를 제거합니다. 저주받은 상태가 아니라면 축복을 받습니다. ";

        DiceController.instance.SetDiceThrow(this, (Character.instance.characterLuck), Character.instance.MinDiceSucc, 6);

    }

    protected override void EventThree()
    {
        activeEvent = 3;

        eventText = "한 교수의 연구실에서 그를 도운 결과 유용한 마법주문 하나를 발견하였습니다. 마법주문 카드 1장을 얻습니다. 대신 투지 체크(-1)를 해야합니다. 실패하면 손버릇 나쁜 학생하나가 당신의 물건 하나를 훔쳐갑니다. 아이템 카드 1장을 선택하여 버립니다.";
        DiceController.instance.SetDiceThrow(this, (Character.instance.characterFight - 1), Character.instance.MinDiceSucc, 6);
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


    public override void EventResult()
    {
        Debug.Log("EventResult()");

        int successCount = DiceController.instance.SuccessOrFailure();

        switch (activeEvent)
        {
            case 1:
                Debug.Log("EventResult().Switch 1: ");

                if (successCount == 0)
                    Character.instance.characterStamina += 1;
                else if (successCount > 0)
                {
                    DiceController.instance.AdditoryDiceValue = true;

                    DiceController.instance.SetDiceThrow(this, 1, 1, 6);

                    Character.instance.characterStamina += DiceController.instance.ResultDiceValue();
                }
                break;
            case 2:
                Debug.Log("EventResult().Switch 2: ");

                if (successCount == 0)
                    Character.instance.characterStamina += 1;
                else if (successCount > 0)
                {
                    DiceController.instance.AdditoryDiceValue = true;

                    DiceController.instance.SetDiceThrow(this, 1, 1, 6);

                    Character.instance.characterStamina += DiceController.instance.ResultDiceValue();
                }
                break;
            case 3:
                Debug.Log("EventResult().Switch 3: ");

                if (successCount == 0)
                    Character.instance.characterStamina += 1;
                else if (successCount > 0)
                {
                    DiceController.instance.AdditoryDiceValue = true;

                    DiceController.instance.SetDiceThrow(this, 1, 1, 6);

                    Character.instance.characterStamina += DiceController.instance.ResultDiceValue();
                }
                break;

        }
    }
}
