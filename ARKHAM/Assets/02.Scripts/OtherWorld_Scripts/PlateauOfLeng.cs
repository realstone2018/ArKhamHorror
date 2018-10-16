using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateauOfLeng : OtherWorld {

    private void Awake()
    {
        OtherWorldId = 4;
        postion = this.transform.position;
        OtherWorld.Simbol simbol = Simbol.Diamond;
    }

    //다른세계에서의 조우 이벤트 작성
}
