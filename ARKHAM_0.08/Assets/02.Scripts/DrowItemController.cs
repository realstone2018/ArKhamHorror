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
        
        
        DrowItemPanel.SetActive(true);

        if (ItemList.instance.NomalItemList.ContainsKey(5))
        {
            ItemList.Item item = ItemList.instance.NomalItemList[Random.Range(1,4)];

            ItemImage.sprite = item.GetImageAction();

            Debug.Log(item);
            Debug.Log("help");
        }
        
        

    }
}
