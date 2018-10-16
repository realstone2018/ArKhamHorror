using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abyss : OtherWorld {



    private void Awake()
    {
        OtherWorldId = 1;
        postion = this.transform.position;
        OtherWorld.Simbol simbol = Simbol.Hexagon;
    }

    //다른세계에서의 조우 이벤트 작성
}
