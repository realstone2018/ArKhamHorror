using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpkeepController1 : MonoBehaviour {

    private int Speed = 0;
    private int Sneak = 0;

    public void SpeedPos1(RectTransform rt)
    {
        Speed = 1;
        Sneak = 4;
        if (1 == Mathf.Abs(Speed -Character.instance.characterSpeed))
        {
            OnClickMove(rt,Speed,Sneak);
        }
    }
    public void SpeedPos2(RectTransform rt)
    {
        Speed = 2;
        Sneak = 3;
        if (1 == Mathf.Abs(Speed - Character.instance.characterSpeed))
        {
            OnClickMove(rt, Speed, Sneak);
        }
    }
    public void SpeedPos3(RectTransform rt)
    {
        Speed = 3;
        Sneak = 2;
        if (1 == Mathf.Abs(Speed - Character.instance.characterSpeed))
        {
            OnClickMove(rt, Speed, Sneak);
        }
    }

    public void SpeedPos4(RectTransform rt)
    {
        Speed = 4;
        Sneak = 1;
        if (1 == Mathf.Abs(Speed - Character.instance.characterSpeed))
        {
            OnClickMove(rt, Speed, Sneak);
        }
    }

    public void OnClickMove(RectTransform rt, int num1, int num2)
    {

        if (Character.instance.characterFocus > 0)
        {
            this.transform.position = rt.transform.position;
            GameObject.FindWithTag("Player").GetComponent<Character>().characterFocus--;
            Character.instance.characterSpeed = num1;
            Character.instance.characterSneak = num2;
        }
    }
}
