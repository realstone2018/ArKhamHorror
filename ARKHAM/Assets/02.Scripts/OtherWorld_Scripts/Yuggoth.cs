using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yuggoth : OtherWorld {

    private void Awake()
    {
        OtherWorldId = 7;
        postion = this.transform.position;
        OtherWorld.Simbol simbol = Simbol.Circle;
    }

    //다른세계에서의 조우 이벤트 작성
}

