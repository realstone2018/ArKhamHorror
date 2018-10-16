using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityoftheGreatRace : OtherWorld {

    private void Awake()
    {
        OtherWorldId = 3;
        postion = this.transform.position;
        OtherWorld.Simbol simbol = Simbol.Triangle;
    }

    //다른세계에서의 조우 이벤트 작성
}
