using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherDimension : OtherWorld {

    private void Awake()
    {
        OtherWorldId = 2;
        postion = this.transform.position;
        OtherWorld.Simbol simbol = Simbol.Square;
    }

    //다른세계에서의 조우 이벤트 작성
}
