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

    public Transform InventoryCard;

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
        ShowInventory();
        
        Character.instance.characterFocus = Character.instance.MaxFocus;

        

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


    public void ShowInventory()
    {
        Transform parentOj = GameObject.FindGameObjectWithTag("Inventory").transform;
        Vector3 parentvector = GameObject.FindGameObjectWithTag("Inventory").transform.position;
        Transform childOj;

        if (0 < Character.instance.CharacterInventory.Count)
        {
            for (int i = 0; i < Character.instance.CharacterInventory.Count; i++)
            {
                childOj = Instantiate(InventoryCard, new Vector3(parentvector.x - 70+(i*24), parentvector.y, parentvector.z), Quaternion.identity, parentOj);
                childOj.GetComponent<Image>().sprite = Character.instance.CharacterInventory[i].ItemImage;
                //아이템 인벤토리 표현 좌표값 수정 요망
            }

        }

    }


}
