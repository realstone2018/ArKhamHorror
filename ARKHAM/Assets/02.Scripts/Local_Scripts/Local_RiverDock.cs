using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Local_RiverDock : Local {

    void Start()
    {
        local_Id = 32;  
        allowLocal_Id = new int[1];
        allowLocal_Id[0] = 30;

        position = transform.position;
    }

    protected override void EventOne()
    {
        Debug.Log(gameObject.name + "EventOne");
    }

    protected override void EventTwo()
    {
        Debug.Log(gameObject.name + "EventTwo");
    }

    protected override void EventThree()
    {
        Debug.Log(gameObject.name + "EventThree");
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
