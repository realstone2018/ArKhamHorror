using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpkeepController2 : MonoBehaviour {

    private int Fight = 0;
    private int Will = 0;

    public void SpeedPos1(RectTransform rt)
    {
        Fight = 1;
        Will = 4;

        if (1 == Mathf.Abs(Fight - Character.instance.characterFight))
        {
            OnClickMove(rt, Fight, Will);
        }
    }
    public void SpeedPos2(RectTransform rt)
    {
        Fight = 2;
        Will = 3;

        if (1 == Mathf.Abs(Fight - Character.instance.characterFight))
        {
            OnClickMove(rt, Fight, Will);
        }
    }
    public void SpeedPos3(RectTransform rt)
    {
        Fight = 3;
        Will = 2;
        if (1 == Mathf.Abs(Fight - Character.instance.characterFight))
        {
            OnClickMove(rt, Fight, Will);
        }
    }
    public void SpeedPos4(RectTransform rt)
    {
        Fight = 4;
        Will = 1;
        if (1 == Mathf.Abs(Fight - Character.instance.characterFight))
        {
            OnClickMove(rt, Fight, Will);
        }
    }
    public void OnClickMove(RectTransform rt, int num1, int num2)
    {
        if (Character.instance.characterFocus > 0)
        {
            this.transform.position = rt.transform.position;
            GameObject.FindWithTag("Player").GetComponent<Character>().characterFocus--;
            Character.instance.characterFight = num1;
            Character.instance.characterWILL = num2;
        }
    }
}
