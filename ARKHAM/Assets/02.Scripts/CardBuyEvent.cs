using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardBuyEvent : MonoBehaviour {

    public GameObject EventPanel;
    public GameObject ItemPanel1;
    public GameObject ItemPanel2;
    public GameObject ItemPanel3;
    public List<ItemCard> Drowcard;
    public GameObject Nomoney;
    

    public static CardBuyEvent instance = null;
    


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Drowcard = ItemDictionary.instance.CommonItemDeck;
    }


    //카드 구입 이벤트시 아이템 종류 드로우
    public void Drowcardsetting(int num)
    {
        
        if(num==1)
        {
            Drowcard = ItemDictionary.instance.CommonItemDeck;
            ItemPanel1.GetComponent<Image>().sprite = Drowcard[0].ItemImage;
            ItemPanel2.GetComponent<Image>().sprite = Drowcard[1].ItemImage;
            ItemPanel3.GetComponent<Image>().sprite = Drowcard[2].ItemImage;
        }
        if(num==2)
        {
            Drowcard = ItemDictionary.instance.UniquItemDeck;
            ItemPanel1.GetComponent<Image>().sprite = Drowcard[0].ItemImage;
            ItemPanel2.GetComponent<Image>().sprite = Drowcard[1].ItemImage;
            ItemPanel3.GetComponent<Image>().sprite = Drowcard[2].ItemImage;
        }

    }

    //아이템 선택시 구매가능 여부 판별 및 구입
    public void SelectItem(int num)
    {
        
        if(Character.instance.money>Drowcard[num].price)
        {
            Character.instance.money -= Drowcard[num].price;
            Character.instance.CharacterInventory.Add(Drowcard[num]);
            
            EventPanel.SetActive(false);
        }
        else
        { 
            GameObject NomoneyPanel= Instantiate(Nomoney, GameObject.Find("Canvas").transform);
            if (GameObject.Find("NomoneyPanel(clone)") ==true)
            {
                Destroy(NomoneyPanel);
            }
            Destroy(NomoneyPanel.gameObject,1.5f);

        }

    }
    //카드 드로우 이벤트
    public void CardDrow(int num)
    {
        ItemDictionary.instance.DrowOneCard(num);

    }


}
