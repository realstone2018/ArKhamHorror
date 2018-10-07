using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpkeepController2 : MonoBehaviour {

    private int Fight1 = 0;
    private int Will1 = 0;

    private int Fight2 = 0;
    private int Will2 = 0;

    private int Fight3 = 0;
    private int Will3 = 0;

    private int Fight4 = 0;
    private int Will4 = 0;


    private void Start()
    {
        Fight1 = Character.instance.characterFight;
        Will1 = Character.instance.characterWILL;

        Fight2 = Fight1 + 1;
        Will2 = Will1 - 1;

        Fight3 = Fight1 + 2;
        Will3 = Will1 - 2;

        Fight4 = Fight1 + 3;
        Will4 = Will1 - 3;
    }

    public void SpeedPos1(RectTransform rt)
    {

        if (1 == Mathf.Abs(Fight1 - Character.instance.characterFight))
        {
            OnClickMove(rt, Fight1, Will1);
        }
    }
    public void SpeedPos2(RectTransform rt)
    {
     

        if (1 == Mathf.Abs(Fight2 - Character.instance.characterFight))
        {
            OnClickMove(rt, Fight2, Will2);
        }
    }
    public void SpeedPos3(RectTransform rt)
    {
       

        if (1 == Mathf.Abs(Fight3 - Character.instance.characterFight))
        {
            OnClickMove(rt, Fight3, Will3);
        }
    }
    public void SpeedPos4(RectTransform rt)
    {
        
        if (1 == Mathf.Abs(Fight4 - Character.instance.characterFight))
        {
            OnClickMove(rt, Fight4, Will4);
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
