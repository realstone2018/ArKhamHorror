using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Street_UpTown : Local {

	void Start () {
        local_Id = 9902491;   //99=아컴지역 136=인접한거리(1번,3번,6번) 94=장소(10의자리9일경우거리 1의자리는 거리 번호)
        allowLocal_Id = new int[5];
        allowLocal_Id[0] = 9900113;
        allowLocal_Id[1] = 9900114;
        allowLocal_Id[2] = 9900115;
        allowLocal_Id[4] = 9901392;
        allowLocal_Id[3] = 9913694;

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
