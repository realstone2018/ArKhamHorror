using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpkeepButtonEvent : MonoBehaviour {

    public GameObject upkeepEncounterPanel;

    public static UpkeepButtonEvent instance;

    public GameObject Inventory;
    public GameObject cluepanel;
    public GameObject moneypanel;
    public GameObject tokenpanel1;
    public GameObject tokenpanel2;

    public Text cluetext;

    private void Awake()
    {
        instance = this;
    }

    //upkeeppanel 활성화
    public void UpkeepEnCounterStep()
    {

        cluepanel.GetComponent<Text>().text = Character.instance.clue.ToString();
        moneypanel.GetComponent<Text>().text = Character.instance.money.ToString();
        tokenpanel1.GetComponent<Text>().text = Character.instance.GateNum.ToString();
        tokenpanel2.GetComponent<Text>().text = Character.instance.SumMonsterHP.ToString();

        upkeepEncounterPanel.SetActive(true);
        Character.instance.ShowInventory();
        Character.instance.characterFocus = 3;

        

    }

    //upkeeppanel 비활성화 및 집중력0으로 변경
    public void UpkeepStepEnd()
    {
        Transform[] childList = Inventory.GetComponentsInChildren<Transform>();
        if (childList.Length>1)
        {
            for (int i = 1; i < childList.Length; i++)
            {
                if (childList[i] != transform)
                {
                    Destroy(childList[i].gameObject);
                }
            }
        }
        
        
        
        upkeepEncounterPanel.SetActive(false);
        Character.instance.characterFocus = 0;
        
    }


}
