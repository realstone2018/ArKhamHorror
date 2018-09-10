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

    public static MythosController instance = null;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        mythosDeck = FindObjectOfType<MythosDeck>();
    }


    public void FirstMythos()
    {
        mythosDeck.FindNotRumor();

        MythosStep();
    }


    public void MythosStep()
    {
        pulledMythos = mythosDeck.DrawCard();

        mythosImage.sprite = Resources.Load<Sprite>("MythosImages/" + pulledMythos.title);
        mythosPanel.SetActive(true);

        // 차원문 생성 


        // 몬스터 생성
        MonsterController.instance.CreateMonster(pulledMythos.gateLocal);

        // 단서 생성
        clue = Instantiate(cluePrefab, pulledMythos.clueLocal.transform);
        clue.transform.localPosition = new Vector3(0, 1.5f, 1.5f);

        // 몬스터 이동 
        for (int i = 0; i < pulledMythos.whiteSimbol.Count; i++) {
            MonsterController.instance.MoveMonster(pulledMythos.whiteSimbol[i], MonsterMoveController.Color.White);
        }

        for (int i = 0; i < pulledMythos.whiteSimbol.Count; i++)
        {
            MonsterController.instance.MoveMonster(pulledMythos.blackSimbol[i], MonsterMoveController.Color.Black);
        }


        pulledMythos.OccurEvent();
    }


    public void MythosStateEnd()
    {
        mythosPanel.SetActive(false);
    }
}
