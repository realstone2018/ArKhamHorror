using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalEventController : MonoBehaviour {

    public Character character;

    public Local eventLocal;

    public GameObject localEncounterPanel;
    public GameObject drawCardPanel;

    public GameObject localCardBuyEvent;
    public GameObject EventPanel;

    public GameObject ItemPanel1;
    public GameObject ItemPanel2;
    public GameObject ItemPanel3;
    public List<ItemCard> Drowcard;



    public Image localImage;
    public Text localFunction;

    public GameObject eventCard;
    public Text localName;
    public Text eventMessage;

    public static LocalEventController instance = null;

    private Vector3 target;
    Vector3 currentPosition;

    //임의의 이벤트 카드 뽑은뒤 선택
    public GameObject SelectLocalEventPanel;
    private int i, j, k;
    private Local tempLocal;

    void Awake()
    {
        instance = this;
    }


    void Start()
    {
        character = GameObject.Find("character").GetComponent<Character>();

        localName = eventCard.transform.GetChild(1).GetComponent<Text>();
        eventMessage = eventCard.transform.GetChild(2).GetComponent<Text>();
    }
    
    
    // 지역 조우 패널 활성화
    public void LocalEnCounterStep()
    {
        //차원문이 있을시 조우단계에서 차원문 닫기 패널 활성화
        if (Character.instance.specialLocalCheck)
        {
            Character.instance.currentMoveCount = Character.instance.maxMoveCount;
            //차원문 닫기 쪽 패널 활성화
            GateController.instance.closePanel();
        }
        else
        {
            Character.instance.currentMoveCount = Character.instance.maxMoveCount;

            /* Local 스크립트의 static함수로 대체
            foreach (Local local in locals)
            {
                if (local.local_Id == character.currentLocal_Id)
                    eventLocal = Local.local;
            }
            */
            eventLocal = Local.GetLocalObjById(character.currentLocal_Id);

            Debug.Log(eventLocal.tag);
            if (eventLocal.tag == "LOCAL")
            {

                localEncounterPanel.SetActive(true);

                //localImage.sprite = Resources.Load("Local_Images/" + eventLocal.name, typeof(Sprite)) as Sprite;
                localImage.sprite = Resources.Load<Sprite>("Local_Images/" + eventLocal.name);

                //추후 text 추가 
                //localFunction.text = eventLocal.localFunction;
            }
        }

    }


    // 지역조우 패널 비활성화,  카드 선택 패널 활성화
    public void LocalEventButtonDown()
    {
        localEncounterPanel.SetActive(false);
        drawCardPanel.SetActive(true);

        drawCardPanel.GetComponent<Animator>().SetBool("Spread", true);
    }

    

    // 카드 선택시 중앙으로 이동, 카드 내 지역 이름 Text변경
    public void SelectCard(Vector3 pos)
    {
        target = eventCard.transform.position;

        eventCard.transform.position = pos;

        eventCard.SetActive(true);

        // MoveTowards 함수로 쓰기 위해 반복
        InvokeRepeating("MoveCenter", 0, 0.3f * Time.deltaTime);

        localName.text = eventLocal.name;
    }


    private void MoveCenter()
    {
        currentPosition = eventCard.transform.position;

        eventCard.transform.position = Vector3.MoveTowards(currentPosition, target,  1.5f);

        // 카드가 원하는 곳에 위치하면 반복 종료, 뒤집는 애니메이션 진행
        if (currentPosition == target)
        {
            FlipCard();
            CancelInvoke();
        }

        Invoke("DeActivationPanel", 1.2f);
    }


    private void FlipCard()
    {
        // 테스트를 위해 랜덤 값
        eventLocal.ActiveEvent(Random.Range(1,3));

        eventMessage.text = eventLocal.eventText;

        eventCard.GetComponent<Animator>().SetBool("Flip", true);
    }


    public void DeActivationPanel() 
    {
        for (int i = 0; i < (drawCardPanel.transform.childCount - 1); i++)
        {
            drawCardPanel.transform.GetChild(i).gameObject.SetActive(false);
        }
    }


    public void ExitEvent()
    {
        drawCardPanel.SetActive(false);

        eventCard.transform.position = currentPosition;
        eventCard.transform.rotation = Quaternion.Euler(0, 180, 0);

        eventCard.transform.GetChild(3).gameObject.SetActive(true);

        // 배경화면 
        drawCardPanel.transform.GetChild(0).transform.localPosition = Vector3.zero;
        drawCardPanel.transform.GetChild(0).gameObject.SetActive(true);
        // 카드 이미지들 
        for (int i = 1; i < (drawCardPanel.transform.childCount - 1); i++)
        {
            drawCardPanel.transform.GetChild(i).transform.position = drawCardPanel.transform.GetChild(1).transform.position;
            drawCardPanel.transform.GetChild(i).gameObject.SetActive(true);
        }
        eventCard.SetActive(false);

    }


    public void CallLocalEvent()
    {
        eventLocal.ActiveEvent(7);
    }

    /*
    // 이벤트 카드 내 세부설명 Text 변경
    public void SetMessage(string eventText)
    {
        eventMessage.text = eventText;
    }
    */

    //상점 아이템 구입 이벤트

    public void LocalBuyEventButtonDown(int n)
    {
        localEncounterPanel.SetActive(false);
        localCardBuyEvent.SetActive(true);


        CardBuyEvent.instance.Drowcardsetting(n);
    }

    public void SelectLocalEvent(int num,Local _local)
    {
        Debug.Log(_local);
        tempLocal = _local;
        SelectLocalEventPanel.SetActive(true);
        switch(num)
        {
            case 1:
                i = Random.Range(1, 3);
                SelectLocalEventPanel.transform.Find("EventCard3").gameObject.SetActive(true);
                GameObject.Find("EventCard3").transform.GetChild(2).GetComponent<Text>().text = _local.TextList[i];
                SelectLocalEventPanel.transform.Find("EventCard1").gameObject.SetActive(false);
                SelectLocalEventPanel.transform.Find("EventCard2").gameObject.SetActive(false);
                break;
            case 2:

                SelectLocalEventPanel.transform.Find("EventCard3").gameObject.SetActive(false);
                j = Random.Range(1, 3);
                SelectLocalEventPanel.transform.Find("EventCard1").gameObject.SetActive(true);
                GameObject.Find("EventCard1").transform.GetChild(2).GetComponent<Text>().text = _local.TextList[j];
                k = Random.Range(1, 3);
                SelectLocalEventPanel.transform.Find("EventCard2").gameObject.SetActive(true);
                GameObject.Find("EventCard2").transform.GetChild(2).GetComponent<Text>().text = _local.TextList[k];
                break;
            case 3:
                i = Random.Range(1, 3);
                GameObject.Find("EventCard3").transform.GetChild(2).GetComponent<Text>().text = _local.TextList[i];
                SelectLocalEventPanel.transform.Find("EventCard3").gameObject.SetActive(true);
                j = Random.Range(1, 3);
                GameObject.Find("EventCard1").transform.GetChild(2).GetComponent<Text>().text = _local.TextList[j];
                SelectLocalEventPanel.transform.Find("EventCard1").gameObject.SetActive(true);
                k = Random.Range(1, 3);
                GameObject.Find("EventCard2").transform.GetChild(2).GetComponent<Text>().text = _local.TextList[k];
                SelectLocalEventPanel.transform.Find("EventCard2").gameObject.SetActive(true);
                break;
        }
    }

    public void SelectLocalEventBtn(int n)
    {
        Debug.Log(tempLocal);
        Debug.Log(n);

        switch (n)
        {
            case 1:
                Debug.Log(i);
                SelectLocalEventPanel.SetActive(false);
                tempLocal.ActiveEvent(i);
                tempLocal = null;i = 0;j = 0;k = 0;
                break;
            case 2:
                Debug.Log(j);
                SelectLocalEventPanel.SetActive(false);
                tempLocal.ActiveEvent(j);
                tempLocal = null; i = 0; j = 0; k = 0;
                break;
            case 3:
                Debug.Log(k);
                SelectLocalEventPanel.SetActive(false);
                tempLocal.ActiveEvent(k);
                tempLocal = null; i = 0; j = 0; k = 0;
                break;
        }
    }
}
