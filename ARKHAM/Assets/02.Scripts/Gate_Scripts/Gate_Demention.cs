using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate_Demention : Gate {

    private void Awake()
    {
        OpenLocal = GameObject.Find("Demention").GetComponent<Local>();
        GateSimbol = Monster.Simbol.Square;
        Modifier = 0;
        GateImage = Resources.Load<Sprite>("GateImages/AnotherDimension");
    }
}
