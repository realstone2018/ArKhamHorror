using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate_Celeano : Gate {

    private void Awake()
    {
        OpenLocal = GameObject.Find("Celeano").GetComponent<Local>();
        GateSimbol = Monster.Simbol.Star;
        Modifier = -1;
        GateImage = Resources.Load<Sprite>("GateImages/GreatHallOfCelano");
    }
}

