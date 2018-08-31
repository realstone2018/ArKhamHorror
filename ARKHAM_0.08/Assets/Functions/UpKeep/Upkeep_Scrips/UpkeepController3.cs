using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpkeepController3 : MonoBehaviour {

    private int Lore= 0;
    private int Luck = 0;

    public void SpeedPos1(RectTransform rt)
    {
        Lore = 1;
        Luck = 4;
        if (1 == Mathf.Abs(Lore - Character.instance.characterLore))
        {
            OnClickMove(rt, Lore, Luck);
        }
    }
    public void SpeedPos2(RectTransform rt)
    {
        Lore = 2;
        Luck = 3;

        if (1 == Mathf.Abs(Lore - Character.instance.characterLore))
        {
            OnClickMove(rt, Lore, Luck);
        }
    }
    public void SpeedPos3(RectTransform rt)
    {
        Lore = 3;
        Luck = 2;
        if (1 == Mathf.Abs(Lore - Character.instance.characterLore))
        {
            OnClickMove(rt, Lore, Luck);
        }
    }
    public void SpeedPos4(RectTransform rt)
    {
        Lore = 4;
        Luck = 1;
        if (1 == Mathf.Abs(Lore - Character.instance.characterLore))
        {
            OnClickMove(rt, Lore, Luck);
        }
    }


    public void OnClickMove(RectTransform rt, int num1, int num2)
    {
        if (Character.instance.characterFocus > 0)
        {
            this.transform.position = rt.transform.position;
            GameObject.FindWithTag("Player").GetComponent<Character>().characterFocus--;
            Character.instance.characterLore = num1;
            Character.instance.characterLuck = num2;
        }
    }
}
