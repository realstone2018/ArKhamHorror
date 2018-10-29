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
        
        GameObject parent = GameObject.Find(openloacl);
        Local sealMarkCheck = parent.GetComponent<Local>();

        if(sealMarkCheck.SealMark)
        {
            Debug.Log("봉인된지역");
        }
        else
        {
            Transform GateLocal = parent.transform.Find("Gate(Clone)"); //불가능

            Debug.Log(GateDeck[0].name);
            if (GateLocal == null)
            {
                GameObject gateClone = Instantiate(GateDeck[0], parent.transform);

                Local otherWold = gateClone.GetComponent<Gate>().OpenLocal;
                if(otherWold.allowLocal_Id[0]==0)
                    otherWold.allowLocal_Id[0] = parent.GetComponent<Local>().local_Id;
                
                else
                    otherWold.allowLocal_Id[1] = parent.GetComponent<Local>().local_Id;


                FinalBattle.instance.DoomTrackCheck();

                GateDeck.RemoveAt(0);
            }
            else
            {
                Debug.Log("차원문 충돌");

            }
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
        CloseGatePanel.SetActive(false);
        CharacterInGate.ClosesGateCheck(n);
    }
}
