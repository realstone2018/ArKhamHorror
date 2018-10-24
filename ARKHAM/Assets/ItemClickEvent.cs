using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemClickEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var button = transform.GetComponent<Button>();
        button.onClick.AddListener(delegate () { this.TaskOnClick(); });
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void TaskOnClick()
    {
        var Inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>().CharacterInventory;

        Debug.Log(Inventory.Find(x => x.ItemName.Contains(GetComponent<ItemCard>().ItemName)));
        ItemCard CardFuntion = Inventory.Find(x => x.ItemName.Contains(GetComponent<ItemCard>().ItemName));//일단돌아가는데 모르겟슴
        //Inventory.Contains(GetComponent<ItemCard>().ItemName);
        CardFuntion.ItemFuntion();
    }
}
