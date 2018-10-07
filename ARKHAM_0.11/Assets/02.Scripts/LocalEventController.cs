using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalEventController : MonoBehaviour {

    public Character character;

    public Local[] locals;
    public Local eventLocal;

    public GameObject localEncounterPanel;
    public GameObject drawCardPanel;

    public GameObject localCardBuyEvent;
    public GameObject EventPanel;
    public GameObject ItemPanel1;
    public GameObject ItemPanel2;
    public GameObject ItemPanel3;
    public List<ItemCard> Drowcard;
    public Sprite aaaaaa;



    public Image localImage;
    public Text localFunction;

    public GameObject eventCard;
    public Text localName;
    public Text eventMessage;

    public static LocalEventController instance = null;

    private Vector3 target;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        character = GameObject.Find("character").GetComponent<Character>();

        locals = GameObject.FindObjectsOfType<Local>();

        localName = eventCard.transform.GetChild(1).GetComponent<Text>();
        eventMessage = eventCard.transform.GetChild(2).GetComponent<Text>();
    }
    /*
    private void Update()
    {
        Debug.Log(Resources.Load("Local_Images/Black_cave", typeof(Sprite)) as Sprite);
    }
    */

    // 지역 조우 패널 활성화
    public void LocalEnCounterStep()
    {
        Character.instance.currentMoveCount = Character.instance.maxMoveCount;
        foreach (Local local in locals)
        {
            if (local.local_Id == character.currentLocal_Id)
                eventLocal = local;
        }

        localEncounterPanel.SetActive(true);


        //localImage.sprite = Resources.Load("Local_Images/" + eventLocal.name, typeof(Sprite)) as Sprite;
        localImage.sprite = Resources.Load<Sprite>("Local_Images/" + eventLocal.name);

        //localFunction.text = eventLocal.localFunction;

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
        Vector3 currentPosition = eventCard.transform.position;

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

    public void LocalBuyEventButtonDown()
    {
        localEncounterPanel.SetActive(false);
        localCardBuyEvent.SetActive(true);


        CardBuyEvent.instance.Drowcardsetting(2);

    }
}
