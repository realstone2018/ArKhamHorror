using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DrowItemController : MonoBehaviour {


    public GameObject DrowItemPanel;
    public Image ItemImage;




    public static DrowItemController instance = null;

    private void Awake()
    {
        instance = this;
    }


    public void DrowItemEncounter()
    {
        int x =Random.Range(1,4);
        
        DrowItemPanel.SetActive(true);
		Debug.Log(x);


        if (ItemList.instance.NomalItemList.ContainsKey(x))
        {
            ItemList.Item item = ItemList.instance.NomalItemList[x];

            ItemImage.sprite = item.GetImageAction();

			
            Debug.Log(item.getPrice()); // 이미지 이외 잘들어감
            Debug.Log("help");
        }
        
        

    }
}
