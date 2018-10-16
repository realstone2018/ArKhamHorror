using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MythosController : MonoBehaviour {

    MythosDeck mythosDeck;
    Mythos pulledMythos;

    public GameObject eventCard;
    public GameObject mythosPanel;
    public Image mythosImage;

    public GameObject cluePrefab;
    public GameObject clue;

    Vector3 currentPosition;
    

    public static MythosController instance = null;

    void Awake()
    {
        instance = this;
        mythosDeck = FindObjectOfType<MythosDeck>();
    }

    private void Start()
    {
        //참조값 없길레 Awake로 옮김
       // mythosDeck = FindObjectOfType<MythosDeck>();
    }


    public void FirstMythos()
    {
        mythosDeck.FindNotRumor();

        FistClue();

        MythosStep();
    }


    //첫 단서 배치
    public void FistClue()
    {

        clue = Instantiate(cluePrefab, GameObject.Find("Woods").GetComponent<Transform>());
<<<<<<< HEAD
        clue.transform.localPosition = new Vector3(0, 1.5f, 1.5f);
          clue = Instantiate(cluePrefab, GameObject.Find("Historical_Society").GetComponent<Transform>());
        clue.transform.localPosition = new Vector3(0, 1.5f, 1.5f);
=======
        clue.transform.localPosition = new Vector3(0, -1.5f, 1.5f);
        clue = Instantiate(cluePrefab, GameObject.Find("Historical_Society").GetComponent<Transform>());
        clue.transform.localPosition = new Vector3(0, -1.5f, 1.5f);
>>>>>>> BossAndGate
        clue = Instantiate(cluePrefab, GameObject.Find("Science_Building").GetComponent<Transform>());
        clue.transform.localPosition = new Vector3(0, -1.5f, 1.5f);
        clue = Instantiate(cluePrefab, GameObject.Find("Unvisited_Isle").GetComponent<Transform>());
        clue.transform.localPosition = new Vector3(0, -1.5f, 1.5f);
        clue = Instantiate(cluePrefab, GameObject.Find("The_Unnamable").GetComponent<Transform>());
        clue.transform.localPosition = new Vector3(0, -1.5f, 1.5f);
        clue = Instantiate(cluePrefab, GameObject.Find("Indefendence_Square").GetComponent<Transform>());
        clue.transform.localPosition = new Vector3(0, -1.5f, 1.5f);
        clue = Instantiate(cluePrefab, GameObject.Find("Hibb's_RoadHouse").GetComponent<Transform>());
        clue.transform.localPosition = new Vector3(0, -1.5f, 1.5f);
        clue = Instantiate(cluePrefab, GameObject.Find("GraveYard").GetComponent<Transform>());
        clue.transform.localPosition = new Vector3(0, -1.5f, 1.5f);
        clue = Instantiate(cluePrefab, GameObject.Find("Black_Cave").GetComponent<Transform>());
        clue.transform.localPosition = new Vector3(0, -1.5f, 1.5f);
        clue = Instantiate(cluePrefab, GameObject.Find("The_Wrrch_House").GetComponent<Transform>());
        clue.transform.localPosition = new Vector3(0, -1.5f, 1.5f);
        clue = Instantiate(cluePrefab, GameObject.Find("Silver_Twilight_Lodge").GetComponent<Transform>());
        clue.transform.localPosition = new Vector3(0, -1.5f, 1.5f);
        

    }


    public void MythosStep()
    {
        StartCoroutine("MythosStepCoroutine");
    }

    IEnumerator MythosStepCoroutine()
    {
        pulledMythos = mythosDeck.DrawCard();

        mythosImage.sprite = Resources.Load<Sprite>("MythosImages/" + pulledMythos.title);
        mythosPanel.SetActive(true);

        currentPosition = eventCard.transform.position;


        // 카드 좌측 상단으로 이동 애니메이션 
        eventCard.GetComponent<Animator>().SetBool("Flip", true);

        // 차원문 생성 
        Gate.instance.OpenGate(pulledMythos.gateLocal.name);

        // 몬스터 생성
        MonsterController.instance.CreateMonster(pulledMythos.gateLocal);

        // 단서 생성
        clue = Instantiate(cluePrefab, pulledMythos.clueLocal.transform);
        clue.transform.localPosition = new Vector3(0, 1.5f, 1.5f);

        // 몬스터 이동 
  
        IEnumerator coroutine = MonsterController.instance.MoveOneByOne(pulledMythos.whiteSimbol, MonsterMoveController.Color.White);
        yield return StartCoroutine(coroutine);
    

        coroutine = MonsterController.instance.MoveOneByOne(pulledMythos.blackSimbol, MonsterMoveController.Color.Black);
        yield return StartCoroutine(coroutine);

        eventCard.GetComponent<Animator>().SetBool("Flip", false);

        pulledMythos.OccurEvent();
    }

    public void MythosStateEnd()
    {
        eventCard.GetComponent<Animator>().SetBool("Reset", true);
        mythosPanel.SetActive(false);

        //eventCard.transform.position = currentPosition;
        //eventCard.transform.rotation = Quaternion.Euler(0, 180, 0);

        eventCard.transform.GetChild(3).gameObject.SetActive(true);
        eventCard.GetComponent<Animator>().SetBool("Reset", false);

        /*
        eventCard.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        eventCard.transform.GetChild(3).GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        eventCard.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(260, 380);
        eventCard.transform.GetChild(3).GetComponent<RectTransform>().sizeDelta = new Vector2(260, 380);
        */
    }
}
