﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Street_NorthSide : Local {

    void Start () {

        local_Id = 00;   //99=아컴지역 136=인접한거리(1번,3번,6번) 94=장소(10의자리9일경우거리 1의자리는 거리 번호)
        allowLocal_Id = new int[5];
        allowLocal_Id[0] = 03;
        allowLocal_Id[1] = 01;
        allowLocal_Id[2] = 02;
        allowLocal_Id[3] = 30;
        allowLocal_Id[4] = 10;

        whitePath_id = 10;
        blackPath_id = 30;

        position = transform.position;
    }


    protected override void EventOne()
    {

    }

    protected override void EventTwo()
    {

    }

    protected override void EventThree()
    {

    }

    protected override void EventFour()
    {

    }

    protected override void EventFive()
    {

    }

    protected override void EventSiz()
    {

    }

    protected override void EventSeven()
    {

    }
}
