﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DrowItemController : MonoBehaviour {


    public GameObject DrowItemPanel;
    public GameObject Item1Panel;
	public GameObject Item2Panel;
	public GameObject Item3Panel;
    private int ItemKins;
	




    public static DrowItemController instance = null;

    private void Awake()
    {
        instance = this;
    }


    public void DrowItemEncounter()
    {
        int x =Random.Range(1,4);
        
        DrowItemPanel.SetActive(true);

        

        if (ItemList.instance.NomalItemList.ContainsKey(x))
        {
            /*
            ItemList.Item item = ItemList.instance.NomalItemList[x];
            
			Item1Panel.GetComponent<ItemInfo1>().CardInfo= item;

			Item1Panel.GetComponent<Image>().sprite = item.GetImageAction();
			x =Random.Range(1,4);
            */
            Item1Panel.GetComponent<Image>().sprite = Array.instance.ItemArray[0].ItemImage;
        }

		if (ItemList.instance.NomalItemList.ContainsKey(x))
        {
            ItemList.Item item = ItemList.instance.NomalItemList[x];
			
            
			Item2Panel.GetComponent<Image>().sprite = item.GetImageAction();

            x =Random.Range(1,4);
        }

		if (ItemList.instance.NomalItemList.ContainsKey(x))
        {
            ItemList.Item item = ItemList.instance.NomalItemList[x];
            
			Item3Panel.GetComponent<Image>().sprite = item.GetImageAction();

            x =Random.Range(1,4);
        }

        Debug.Log("end");

    }


	public void CharacterGetItem(int n)
	{
		DrowItemPanel.SetActive(false);
//		Character.instance.CharacterGetItemList.add(1,Item1Panel.GetComponent<ItemInfo1>().CardInfo );
	

	
	}
}
