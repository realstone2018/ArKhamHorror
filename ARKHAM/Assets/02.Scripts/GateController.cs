using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GateController : MonoBehaviour {
    public GameObject AbyssGate;
    public GameObject CeleanoGate;
    public GameObject DementionGate;
    public GameObject DreamLandGate;
    public GameObject GreatRaceGate;
    public GameObject PlateauOfLengGate;
    public GameObject RlyehGate;
    public GameObject YuggoyhGate;
    public List<GameObject> GateDeck;


    public GameObject CloseGatePanel;
    public Image GateImage;

    public Gate CharacterInGate;

    public static GateController instance = null;

    private void Awake()
    {
        instance = this;
        GateDeck = new List<GameObject>();

        GateDeck.Add(AbyssGate);
        GateDeck.Add(CeleanoGate);
        GateDeck.Add(DementionGate);
        GateDeck.Add(DreamLandGate);
        GateDeck.Add(GreatRaceGate);
        GateDeck.Add(PlateauOfLengGate);
        GateDeck.Add(RlyehGate);
        GateDeck.Add(YuggoyhGate);
        GateDeck.Add(AbyssGate);
        GateDeck.Add(CeleanoGate);
        GateDeck.Add(DementionGate);
        GateDeck.Add(DreamLandGate);
        GateDeck.Add(GreatRaceGate);
        GateDeck.Add(PlateauOfLengGate);
        GateDeck.Add(RlyehGate);
        GateDeck.Add(YuggoyhGate);

        GateDeck = ShuffleList<GameObject>(GateDeck);
    }

    public void OpenGate(string openloacl)
    {

        GameObject child = GameObject.Find(openloacl);
        Transform GateLocal = child.transform.Find("Gate(Clone)");

        if (GateLocal == null )
        {
            Instantiate(GateDeck[0], GameObject.Find(openloacl).transform);
            FinalBattle.instance.DoomTrack = +1;
            GateDeck.RemoveAt(0);
        }
        else
        {
            Debug.Log("차원문 충돌");

        }
    }


    //배열 요소 랜덤 배치
    private List<GameObject> ShuffleList<GameObject>(List<GameObject> inputList)
    {
        List<GameObject> randomList = new List<GameObject>();

        int randomIndex = 0;
        while (inputList.Count > 0)
        {
            randomIndex = Random.Range(0, inputList.Count); 
            randomList.Add(inputList[randomIndex]); 
            inputList.RemoveAt(randomIndex);
        }

        return randomList; 
    }


    public void closePanel()
    {
        CloseGatePanel.SetActive(true);
        GateImage.sprite = CharacterInGate.GateImage;

    }


    public void closeGateBtn(int n)
    {
        CharacterInGate.ClosesGateCheck(n);
    }
}
