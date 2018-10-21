using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Local_Abyss : Local
{
    public int activeEvent;
    

    void Start()
    {
        local_Id = 112;
        allowLocal_Id = new int[2];

        position = transform.position;
        TextList = new string[4];
        TextList[0]= "연못 옆에서 쉬고 있습니다. 행운 체크 (-1)를 합니다. 성공하면 특별 아이템 카드 1장과 $3을 얻습니다.";
        TextList[1] = "행운이 찾아왔습니다. 비축물을 쌓아 놓은 저장고에 떨어졌습니다.일반 아이템 카드 1장을 얻습니다.";
        TextList[2] = "정신적인 압박이 느껴집니다. 정신력1을 잃습니다.";
        TextList[3] = "행운 체크 (-1)을 합니다. 실패하면 마치 거대한 생물의 발톱에 의해 새겨진 것처럼 기이한 표식을 가진 수많은 산을 대면합니다. 세계가 당신을 휘감고 있습니다. 정신력 3을 잃습니다.";
    }

    protected override void EventOne()
    {
        activeEvent = 1;
        eventText = "검고 눈먼 고기로 가득 찬 작고 빛나는 연못 옆에서 쉬고 있습니다. 행운 체크 (-1)를 합니다. 성공하면 물속에서 일반적이지 않은 물건을 발견하여 낚아챕니다. 특별 아이템 카드 1장과 $3을 얻습니다.";
        DiceController.instance.SetDiceThrow(this, Character.instance.characterLuck - 1, Character.instance.MinDiceSucc, 6);
    }

    protected override void EventTwo()
    {
        activeEvent = 2;
        eventText = "행운이 찾아왔습니다. 비축물을 쌓아 놓은 저장고에 떨어졌습니다. 일반 아이템 카드 1장을 얻습니다.";
        ItemDictionary.instance.DrowOneCard(1);
    }

    protected override void EventThree()
    {
        activeEvent = 3;
        eventText = "정신적인 압박이 느껴집니다. 정신력1을 잃습니다.";
        Character.instance.characterSanity -=1;
    }

    protected override void EventFour()
    {
        activeEvent = 4;
        eventText = "행운 체크 (-1)을 합니다. 실패하면 마치 거대한 생물의 발톱에 의해 새겨진 것처럼 기이한 표식을 가진 수많은 산을 대면합니다. 세계가 당신을 휘감고 있습니다. 정신력 3을 잃습니다.";
        DiceController.instance.SetDiceThrow(this,Character.instance.characterLuck-1,Character.instance.MinDiceSucc,6);
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
                if (_successCount > 0)
                {
                    ItemDictionary.instance.DrowOneCard(2);
                    Character.instance.money += 3;
                }
                else
                    Debug.Log("실패");
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                if (_successCount == 0)
                { 
                    Character.instance.characterSanity -= 3;
                }
                else
                    Debug.Log("실패");
                break;
        }
    }
}