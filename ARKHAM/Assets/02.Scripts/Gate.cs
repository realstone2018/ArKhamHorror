using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {
    public GameObject GatePrefab;

    public static Gate instance = null;

    private void Awake()
    {
        instance = this;
    }

    public void OpenGate(string openloacl)
    {

        GameObject child = GameObject.Find(openloacl);


        if (child.transform.Find(GatePrefab.name).name == null )
        {
            Debug.Log("차원문 충돌");
        }
        else
        {
            Instantiate(GatePrefab, GameObject.Find(openloacl).transform);
           
        }
    }
}
