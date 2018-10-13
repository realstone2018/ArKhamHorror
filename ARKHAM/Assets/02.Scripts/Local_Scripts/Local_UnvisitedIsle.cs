using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Local_UnvisitedIsle : Local {

    void Awake()
    {
        local_Id = 33;   
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
