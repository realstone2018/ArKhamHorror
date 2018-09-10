using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Array : MonoBehaviour {

    public GameObject ItemPrefab;
    public ItemInfomation[] ItemArray= new ItemInfomation[3];

    public static Array instance = null;
    // Use this for initialization
    void Awake () {
        
        var ItemSub = Instantiate(ItemPrefab) as GameObject;
        ItemSub.AddComponent<TommyGun>();
        


        instance = this;

        ItemArray[0] = new TommyGun();

        ItemArray[0] = ItemSub.GetComponent<TommyGun>();


        
        ItemArray[1] = new DarkCloak();
        ItemArray[2] = new OldJournal();


    }
	
}
