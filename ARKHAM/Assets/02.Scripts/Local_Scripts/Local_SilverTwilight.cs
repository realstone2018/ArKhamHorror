using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Local_SilverTwilight : Local {
    public int activeEvent;

    void Awake()
    {
        local_Id = 62;   //99=아컴지역 004=인접한거리(1번,3번,6번) 02=장소번호
        allowLocal_Id = new int[1];
        allowLocal_Id[0] = 60;

        TextList = new string[3];
        TextList[0]=  "지식 체크(-1)를 합니다. 성공하면 단서 마커 3개를 얻습니다. 실패하면 가지고 있는 모든 단서 마커를 잃고 프랑스 언더의 거리로 이동합니다.";
        TextList[1] = "홀에 있는 수상한 물체를 관찰하는 중에 피부가 잡아 당겨지며 꽉 죄이는 느낌을 받았습니다. 행운 체크(-1)를 합니다. 실패하면 저주를 받습니다.";
        TextList[2] = "은둔 체크(-2)를 합니다. 성공하면 실버 트와일라이트의 신전에 숨어 들어가서 흥비로운 물건 2개를 발견합니다. 각각의 물품에 대해 주사위를 굴리고 성공한 주사위가 나오면 특별아이템 카드를, 실패한 주사위가 나오면 일반 아이템 카드를 얻습니다. 실패하면 아무일도 일어나지 않습니다.";


        position = transform.position;
    }

    protected override void EventOne()
    {
        activeEvent = 1;
        eventText = "칼 스탠포드가 당신을 서재로 데려가 이야기를 하려 합니다. 그의 말을 듣는 동안 무섭고 차가운 기운이 당신을 감쌉니다. 지식 체크(-1)를 합니다. 성공하면 고대 마법사의 시험을 통과하여 뭔가 값진 것을 배울 수 있습니다. 단서 마커 3개를 얻습니다. 실패하면 최면에 빠져 잠이 듭니다. 잠깐 대화한 것 같았지만, 서재를 나왔더니 무척 혼란스러워졋습니다. 가지고 있는 모든 단서 마커를 잃고 프랑스 언더의 거리로 이동합니다.";
        DiceController.instance.SetDiceThrow(this, Character.instance.characterLore - 1, Character.instance.MinDiceSucc, 6);
    }

    protected override void EventTwo()
    {
        activeEvent = 2;
        eventText = "홀에 있는 수상한 물체를 관찰하는 중에 피부가 잡아 당겨지며 꽉 죄이는 느낌을 받았습니다. 행운 체크(-1)를 합니다. 실패하면 저주를 받습니다.";
        DiceController.instance.SetDiceThrow(this, Character.instance.characterLuck - 1, Character.instance.MinDiceSucc, 6);
    }

    protected override void EventThree()
    {
        activeEvent = 2;
        eventText = "은둔 체크(-2)를 합니다. 성공하면 실버 트와일라이트의 신전에 숨어 들어가서 흥비로운 물건 2개를 발견합니다. 각각의 물품에 대해 주사위를 굴리고 성공한 주사위가 나오면 특별아이템 카드를, 실패한 주사위가 나오면 일반 아이템 카드를 얻습니다. 실패하면 아무일도 일어나지 않습니다.";
        DiceController.instance.SetDiceThrow(this, Character.instance.characterSneak - 2, Character.instance.MinDiceSucc, 6);
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
                if (_successCount > 0)
                {
                    Character.instance.clue += 3;
                }
                else
                {
                    Character.instance.clue = 0;
                    GameObject Player = GameObject.FindGameObjectWithTag("Player");
                    GameObject FrenchHill = GameObject.Find("French_Hill");
                    Player.transform.position =new Vector3(FrenchHill.transform.position.x,1.2f, FrenchHill.transform.position.z);
                }
                break;
            case 2:
                if (_successCount == 0)
                {
                    if (Character.instance.MinDiceSucc==5)
                        Character.instance.MinDiceSucc = 6;
                    else if(Character.instance.MinDiceSucc == 4)
                        Character.instance.MinDiceSucc = 5;
                }
                break;
            case 3:
                if (_successCount > 0)
                {
                    DiceController.instance.AdditoryDiceValue = true;
                    DiceController.instance.SetDiceThrow(this, 1, Character.instance.MinDiceSucc, 6);

                    if (DiceController.instance.ResultDiceValue() > Character.instance.MinDiceSucc - 1)
                        ItemDictionary.instance.DrowOneCard(2);
                    else
                        ItemDictionary.instance.DrowOneCard(1);

                    DiceController.instance.AdditoryDiceValue = true;
                    DiceController.instance.SetDiceThrow(this, 1, Character.instance.MinDiceSucc, 6);

                    if (DiceController.instance.ResultDiceValue() > Character.instance.MinDiceSucc - 1)
                        ItemDictionary.instance.DrowOneCard(2);
                    else
                        ItemDictionary.instance.DrowOneCard(1);


                }
                else
                {
                    Debug.Log("실패");
                }
                break;
                break;
            case 4:
                
                break;
        }
    }
}
