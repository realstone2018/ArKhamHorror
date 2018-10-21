using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Local_BoardingHouse : Local {
    public int activeEvent;
    public GameObject SelectPanel;
    
    void Awake () {
        local_Id = 81;   //99=아컴지역 004=인접한거리(1번,3번,6번) 02=장소번호
        allowLocal_Id = new int[1];
        allowLocal_Id[0] = 80;

        position = transform.position;
    }


    protected override void EventOne()
    {
        activeEvent = 1;
        eventText = "지하실에 입구가 허술하게 덮인 통로를 발견하였습니다. 이를 열어 보니 구불구불한 터널이 나왔습니다. 이 터널을 탐사하면 실버 트와일라이트에 도달합니다. 실버 트와일라이트로 이동하고 장소 카드 2장을 뽑습니다. 둘 중 원하는 장소 카드의 지시를 따르고 다른 1장은 버립니다.";
        StartCoroutine(MoveController.instance.MovePosition(GameObject.Find("Silver_Twilight_Lodge").GetComponent<Transform>().position));
        Debug.Log("실버트와일라잇 에서 조우 진행 2개중 한개 선택지");
        EventResult(0);
    }

    protected override void EventTwo()
    {
        activeEvent = 2;
        eventText = "누군가의 방을 새롭게 칠하려 합니다. 행운 체크(+0)를 합니다. 성공하면 드림랜드로 이동합니다. 드림랜드에서의 조우 하나를 처리하고 즉시 마의 하숙집으로 돌아옵니다. 실패하면 어비스로 이동합니다. 어비스에서의 조우 하나를 처리하고 즉시 마의 하숙집으로 돌아옵니다.";
        DiceController.instance.SetDiceThrow(this, Character.instance.characterLuck, Character.instance.MinDiceSucc, 6);
        
    }

    protected override void EventThree()
    {
        activeEvent = 3;
        eventText = "이웃에서 계속해서 외쳐대는 통에 꼬박 밤을 새웠습니다. 행운 체크(-1)를 합니다. 실패하면 정신력이나 체력중 하나를 선택하여 1 잃습니다. ";
        DiceController.instance.SetDiceThrow(this, Character.instance.characterLuck-1, Character.instance.MinDiceSucc, 6);
       
        

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
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        switch (activeEvent)
        {
            case 1:
                
                Local SiverT = GameObject.Find("Silver_Twilight_Lodge").GetComponent<Local>();
                Player.transform.position = new Vector3(SiverT.transform.position.x, 1.2f, SiverT.transform.position.z);
                Debug.Log("실버트라일 라잇에서 조우 2개중 하나 선택진행");
                LocalEventController.instance.SelectLocalEvent(2, SiverT);
                Debug.Log("실버트라일 라잇에서 조우 2개중 하나 선택진행 끝");
                break;

            case 2:
                if(_successCount==0)
                {
                    GameObject otherWorld = GameObject.Find("Abyss");
                    Player.transform.position = otherWorld.transform.position;
                    Debug.Log("어비스조우진행");
                    LocalEventController.instance.SelectLocalEvent(1, otherWorld.GetComponent<Local>());
                    Player.transform.position = new Vector3(transform.position.x,1.2f,transform.position.z);

                }
                else
                {
                    GameObject otherWorld = GameObject.Find("DreamLands");
                    Player.transform.position = otherWorld.transform.position;
                    Debug.Log("드림월드조우진행");
                    LocalEventController.instance.SelectLocalEvent(1, otherWorld.GetComponent<Local>());
                    Player.transform.position = new Vector3(transform.position.x, 1.2f, transform.position.z);
                }
                break;
            case 3:
                if(_successCount==0)
                {
                    SelectPanel.SetActive(true);
                }

                break;
        }
    }

    public void threeEventBtn(int i)
    {
        if(i==0)
            Character.instance.characterSanity -= 1;
        if(i==1)
            Character.instance.characterStamina -= 1;
        SelectPanel.SetActive(false);
    }
}
