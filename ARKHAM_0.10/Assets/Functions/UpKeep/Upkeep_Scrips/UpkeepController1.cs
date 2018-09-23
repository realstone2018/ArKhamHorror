using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpkeepController1 : MonoBehaviour {

    private int Speed1 = 0;
    private int Sneak1 = 0;

    private int Speed2 = 0;
    private int Sneak2 = 0;

    private int Speed3 = 0;
    private int Sneak3 = 0;

    private int Speed4 = 0;
    private int Sneak4 = 0;


    private void Start()
    {
        Speed1 = Character.instance.characterSpeed;
        Sneak1 = Character.instance.characterSneak;

        Speed2 = Speed1+1;
        Sneak2 = Sneak1-1;

        Speed3 = Speed1+2;
        Sneak3 = Sneak1+2;

        Speed4 = Speed1+3;
        Sneak4 = Sneak1-3;
    }

    public void SpeedPos1(RectTransform rt)
    {

        if (1 == Mathf.Abs(Speed1 -Character.instance.characterSpeed))
        {
            OnClickMove(rt,Speed1,Sneak1);
        }
    }
    public void SpeedPos2(RectTransform rt)
    {

        if (1 == Mathf.Abs(Speed2 - Character.instance.characterSpeed))
        {
            OnClickMove(rt, Speed2, Sneak2);
        }
    }
    public void SpeedPos3(RectTransform rt)
    {

        if (1 == Mathf.Abs(Speed3 - Character.instance.characterSpeed))
        {
            OnClickMove(rt, Speed3, Sneak3);
        }
    }

    public void SpeedPos4(RectTransform rt)
    {

        if (1 == Mathf.Abs(Speed4 - Character.instance.characterSpeed))
        {
            OnClickMove(rt, Speed4, Sneak4);
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
