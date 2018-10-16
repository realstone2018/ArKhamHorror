using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheDreamlands : OtherWorld {

    private void Awake()
    {
        OtherWorldId = 6;
        postion = this.transform.position;
        OtherWorld.Simbol simbol = Simbol.BackSlash;
    }

    //다른세계에서의 조우 이벤트 작성
}
