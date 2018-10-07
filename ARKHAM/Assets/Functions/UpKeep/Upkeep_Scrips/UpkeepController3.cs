using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpkeepController3 : MonoBehaviour {

    private int Lore1 = 0;
    private int Luck1 = 0;

    private int Lore2 = 0;
    private int Luck2 = 0;

    private int Lore3 = 0;
    private int Luck3 = 0;

    private int Lore4 = 0;
    private int Luck4 = 0;

    private void Start()
    {
        Lore1 = Character.instance.characterLore;
        Luck1 = Character.instance.characterLuck;

        Lore2 = Lore1 + 1;
        Luck2 = Luck1 - 1;

        Lore3 = Lore1 + 2;
        Luck3 = Luck1 - 2;

        Lore4 = Lore1 + 3;
        Luck4 = Luck1 - 3;

    }

    public void SpeedPos1(RectTransform rt)
    {

        if (1 == Mathf.Abs(Lore1 - Character.instance.characterLore))
        {
            OnClickMove(rt, Lore1, Luck1);
        }
    }
    public void SpeedPos2(RectTransform rt)
    {

        if (1 == Mathf.Abs(Lore2 - Character.instance.characterLore))
        {
            OnClickMove(rt, Lore2, Luck2);
        }
    }
    public void SpeedPos3(RectTransform rt)
    {

        if (1 == Mathf.Abs(Lore3 - Character.instance.characterLore))
        {
            OnClickMove(rt, Lore3, Luck3);
        }
    }
    public void SpeedPos4(RectTransform rt)
    {

        if (1 == Mathf.Abs(Lore4 - Character.instance.characterLore))
        {
            OnClickMove(rt, Lore4, Luck4);
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
