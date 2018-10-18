using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Local_Administration : Local {
    public int activeEvent = 0;

    void Awake()
    {
        local_Id = 52;   //99=아컴지역 004=인접한거리(1번,3번,6번) 02=장소번호
        allowLocal_Id = new int[1];
        allowLocal_Id[0] = 50;

        position = transform.position;
    }

    protected override void EventOne()
    {
        eventText = "당신이 신화에 대해 논쟁한 것 때문에 대학경비들이 당신이 정신 나갔다고 결론을 내렸습니다. 경비들에게 끌려 아컴 정신병원에 수용됩니다. 아컴 정신병원으로 이동합니다. 이곳에서" +
            "장소카드를뽑아 그 지시에 따릅니다.";
        StartCoroutine(MoveController.instance.MovePosition(GameObject.Find("ST.Marys_Hospital").GetComponent<Transform>().position));
        //해당 장소에서의 조우 구현 

    }

    protected override void EventTwo()
    {
        activeEvent = 2;
        eventText = "대학 총장에게 논문 하나를 팔 기회를 얻었습니다. 지식 체크(-1)를 합니다. 성공하면 논문을 팔고 5$를 얻습니다.";
        DiceController.instance.SetDiceThrow(this, (Character.instance.characterLore-1), Character.instance.MinDiceSucc, 6);
    }

    protected override void EventThree()
    {
        eventText = "학장이 당신의 견문을 넓혀줄 인류학 교수를 소개시켜줍니다. 단서마커 1개를 얻습니다.";

        Character.instance.clue += 1;
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
                if (successCount > 0)
                {
                    Character.instance.money += 5;
                }
                break;
            case 3:
                

                break;
        }
    }
}
