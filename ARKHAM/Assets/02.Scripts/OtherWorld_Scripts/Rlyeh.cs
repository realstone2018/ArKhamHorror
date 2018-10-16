using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rlyeh : OtherWorld {

    private void Awake()
    {
        OtherWorldId = 5;
        postion = this.transform.position;
        OtherWorld.Simbol simbol = Simbol.Cross;
    }

    //다른세계에서의 조우 이벤트 작성
}
