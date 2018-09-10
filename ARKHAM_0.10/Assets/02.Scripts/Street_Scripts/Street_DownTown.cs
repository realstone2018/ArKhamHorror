using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Street_DownTown : Local {

    void Start ()
    {
        local_Id = 9967998;   //99=아컴지역 136=인접한거리(1번,3번,6번) 94=장소(10의자리9일경우거리 1의자리는 거리 번호)
        allowLocal_Id = new int[6];
        allowLocal_Id[0] = 9900804;
        allowLocal_Id[1] = 9900802;
        allowLocal_Id[2] = 9900803;
        allowLocal_Id[3] = 99458996;
        allowLocal_Id[4] = 9905897;
        allowLocal_Id[5] = 9906899;

        whitePath_id = 9905897;
        blackPath_id = 9906899;

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
