using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBoss : MonoBehaviour {

    public static SelectBoss instance = null;
    public GameObject BossPrifab1;
    public GameObject BossPrifab2;
    public GameObject BossPrifab3;

    public void Awake()
    {
        instance = this;
    }

    public void PickBoss(int num)
    {
        switch (num)
        {
            case 0:
                Instantiate(BossPrifab1, new Vector3(0,0,0), Quaternion.identity);
                break;
            case 1:
                Instantiate(BossPrifab2, new Vector3(0, 0, 0), Quaternion.identity);
                break;
            case 2:
                Instantiate(BossPrifab3, new Vector3(0, 0, 0), Quaternion.identity);
                break;


        }
    }

   
    
}
