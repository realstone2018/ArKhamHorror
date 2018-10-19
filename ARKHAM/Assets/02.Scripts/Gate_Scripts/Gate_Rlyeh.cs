using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate_Rlyeh : Gate {

    private void Awake()
    {
        OpenLocal = GameObject.Find("Rlyeh").GetComponent<Local>();
        GateSimbol = Monster.Simbol.Cross;
    }

}
