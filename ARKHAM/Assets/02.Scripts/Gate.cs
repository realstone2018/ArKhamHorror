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
        Transform GateLocal = child.transform.Find("Gate(Clone)");




        if (GateLocal == null )
        {
            Instantiate(GatePrefab, GameObject.Find(openloacl).transform);
            FinalBattle.instance.DoomTrack = +1;
           
        }
        else
        {
            Debug.Log("차원문 충돌");

        }
    }
}
