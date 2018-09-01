using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrowItemController : MonoBehaviour {


    public GameObject DrowItemPanel;




    public static DrowItemController instance = null;

    private void Awake()
    {
        instance = this;
    }


    public void DrowItemEncounter()
    {
        DrowItemPanel.SetActive(true);


    }
}
