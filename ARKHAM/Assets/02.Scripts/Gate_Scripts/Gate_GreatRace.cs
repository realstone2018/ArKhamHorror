using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate_GreatRace : Gate {

    private void Awake()
    {
        OpenLocal = GameObject.Find("Abyss").GetComponent<Local>();
        GateSimbol = Monster.Simbol.Triangle;
    }
}
