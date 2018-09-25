using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Street_SouthSide : Local {

    void Start () {
        local_Id = 9901392;   //99=아컴지역 136=인접한거리(1번,3번,6번) 94=장소(10의자리9일경우거리 1의자리는 거리 번호)
        allowLocal_Id = new int[5];
        allowLocal_Id[0] = 9900216;
        allowLocal_Id[1] = 9900217;
        allowLocal_Id[2] = 9900218;
        allowLocal_Id[4] = 9902491;
        allowLocal_Id[3] = 9924593;

        whitePath_id = 9902491;
        blackPath_id = 9924593;

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
