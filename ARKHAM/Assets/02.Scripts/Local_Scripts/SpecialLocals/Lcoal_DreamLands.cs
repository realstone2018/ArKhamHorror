using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lcoal_DreamLands : Local
{
    public int activeEvent;

    void Start()
    {
        local_Id = 116;
        allowLocal_Id = new int[2];

        position = transform.position;

        TextList = new string[4];
        TextList[0] = "지하 세계의 절벽을 기어오르는 중에 주머니가 어딘가에 걸려 찢어졌습니다. 속도 체크(-1)를 합니다. 실패하면 가지고 있는 돈을 모두 잃습니다.";
        TextList[1] = "화산이 폭발하였습니다. 속도 체크(-1)를 합니다. 실패하면 체력 3을 잃습니다.";
        TextList[2] = "화산이 폭발하였습니다. 속도 체크(-1)를 합니다. 실패하면 체력 3을 잃습니다.";
        TextList[3] = "짧은 순간 집의 전경이 뇌리를 스치고 희망이 생겼습니다. 정신력 1을 회복합니다.";
    }

    protected override void EventOne()
    {
        activeEvent = 1;
        eventText = "지하 세계의 절벽을 기어오르는 중에 주머니가 어딘가에 걸려 찢어졌습니다. 속도 체크(-1)를 합니다. 실패하면 가지고 있는 돈을 모두 잃습니다.";
        DiceController.instance.SetDiceThrow(this, Character.instance.characterSpeed - 1, Character.instance.MinDiceSucc, 6);
    }

    protected override void EventTwo()
    {
        activeEvent = 2;
        eventText = "화산이 폭발하였습니다. 속도 체크(-1)를 합니다. 실패하면 체력 3을 잃습니다.";
        DiceController.instance.SetDiceThrow(this, Character.instance.characterSpeed - 1, Character.instance.MinDiceSucc, 6);
    }

    protected override void EventThree()
    {
        activeEvent = 3;
        eventText = "짧은 순간 집의 전경이 뇌리를 스치고 희망이 생겼습니다. 정신력 1을 회복합니다.";
        Character.instance.characterSanity += 1;
    }

    protected override void EventFour()
    {
        activeEvent = 4;
        eventText = "돌의 한 면에 드림랜드에 대한 중대한 비밀이 담겨 있습니다. 지식 체크(-1)[2]를 합니다. 성공하면 단서 마커 4개를 얻습니다. 실패하면 당신의 남아있는 정신마저 갈기갈기 찢깁니다 정신력 전부를 잃습니다.";

        DiceController.instance.SetDiceThrow(this, Character.instance.characterLore - 1, 2, 6);
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
                if (_successCount == 0)
                {
                    Character.instance.money = 0;
                }
                break;
            case 2:
                if (_successCount == 0)
                {
                    Character.instance.DamagedStamina(3);
                }
                break;
            case 3:
                break;
            case 4:
                if (_successCount == 0)
                {
                    Character.instance.DamagedSanity(Character.instance.characterSanity);
                }
                else
                {
                    Character.instance.clue += 4;
                }
                break;
        }
    }
}