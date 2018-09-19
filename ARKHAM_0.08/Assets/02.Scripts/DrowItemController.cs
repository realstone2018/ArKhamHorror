using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DrowItemController : MonoBehaviour {


    public GameObject DrowItemPanel;
    public GameObject Item1Panel;
	public GameObject Item2Panel;
	public GameObject Item3Panel;

    ItemList DrowCardOne;
    ItemList DrowCardTwo;
    ItemList DrowCardThree;

    ItemList tempItem;



    public static DrowItemController instance = null;

    private void Awake()
    {
        instance = this;
    }

    //아이템 구입 관련 함수
    //임시로 아이템 획득으로 넣어놓음
    public void ShopBuyEvent()
    {
        
        DrowItemPanel.SetActive(true);
		

        ItemList DrowCardOne = ItemDeck.instance.DrowCard(0);
        ItemList DrowCardTwo = ItemDeck.instance.DrowCard(1);
        ItemList DrowCardThree = ItemDeck.instance.DrowCard(2);

        Item1Panel.GetComponent<Image>().sprite = DrowCardOne.ItemImage;
        Item2Panel.GetComponent<Image>().sprite = DrowCardTwo.ItemImage;
        Item3Panel.GetComponent<Image>().sprite = DrowCardThree.ItemImage;

    }
    //선택 아이템 구입
    public void ItemBuy(int ItemNumber)
    {
        if (ItemNumber == 0)
        {
            Character.instance.characterInventory.Add(DrowCardOne);
            Character.instance.addInventory();
            Debug.Log("1번째");
        }
        else if (ItemNumber == 1)
        {
            Character.instance.characterInventory.Add(DrowCardTwo);
            Debug.Log("2번째");
        }
        else if (ItemNumber == 2)
        {
            Character.instance.characterInventory.Add(DrowCardThree);
            Debug.Log("3번째");
        }
        else
            Debug.Log("예외");

    }

    
}
