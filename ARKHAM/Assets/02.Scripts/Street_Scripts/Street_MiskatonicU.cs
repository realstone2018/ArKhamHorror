using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Street_MiskatonicU : Local {

    void Start () {    
        local_Id = 50;   //99=아컴지역 136=인접한거리(1번,3번,6번) 94=장소(10의자리9일경우거리 1의자리는 거리 번호)
        allowLocal_Id = new int[6];
        allowLocal_Id[0] = 51;
        allowLocal_Id[1] = 53;
        allowLocal_Id[2] = 52;
        allowLocal_Id[3] = 70;
        allowLocal_Id[4] = 60;
        allowLocal_Id[5] = 30;

        whitePath_id = 30;
        blackPath_id = 70;

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
