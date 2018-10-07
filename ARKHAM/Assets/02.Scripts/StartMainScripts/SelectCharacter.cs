using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour {

    public Character Characterset;

    public static SelectCharacter instance = null;

    public void Awake()
    {
        instance = this;
    }

    public void PickCharacter(int num)
    {
        switch(num)
        {
            case 0:
                AmandaSharpe();
                break;
            case 1:
                AshcanPete();
                break;
            case 2:
                BobJenkins();
                break;


        }
    }

    //임시 스텟부여
    public void AmandaSharpe()
    {
        Characterset.characterSanity = 5;
        Characterset.MaxcharacterSanity = 5;

        Characterset.characterStamina = 5;
        Characterset.MaxcharacterStamina = 5;

        Characterset.characterSpeed = 1;
        Characterset.characterSneak = 4;

        Characterset.characterFight = 1;
        Characterset.characterWILL = 4;

        Characterset.characterLore = 1;
        Characterset.characterLuck = 4;

        Characterset.MaxFocus = 3;
        Characterset.characterFocus = 3;

        Characterset.MinDiceSucc = 5;

        Characterset.money = 1;
        Characterset.clue = 1;

        Characterset.currentLocal_Id = 9900411;

        Characterset.SheetImage = Resources.Load<Sprite>("Sheet/AmandaSharpe");

    }

    public void AshcanPete()
    {
        Debug.Log("AshcanPete");
        Characterset.characterSanity = 4;
        Characterset.MaxcharacterSanity = 4;

        Characterset.characterStamina = 6;
        Characterset.MaxcharacterStamina = 6;

        Characterset.characterSpeed = 0;
        Characterset.characterSneak = 6;

        Characterset.characterFight = 2;
        Characterset.characterWILL = 5;

        Characterset.characterLore = 0;
        Characterset.characterLuck = 3;

        Characterset.MaxFocus = 1;
        Characterset.characterFocus = 1;

        Characterset.MinDiceSucc = 5;

        Characterset.money = 1;
        Characterset.clue = 3;

        Characterset.currentLocal_Id = 9900608;

        Characterset.SheetImage = Resources.Load<Sprite>("Sheet/AshcanPete");
    }
    public void BobJenkins()
    {
        Debug.Log("BobJenkins");
        Characterset.characterSanity = 4;
        Characterset.MaxcharacterSanity = 4;

        Characterset.characterStamina = 6;
        Characterset.MaxcharacterStamina = 6;

        Characterset.characterSpeed = 2;
        Characterset.characterSneak = 3;

        Characterset.characterFight = 1;
        Characterset.characterWILL = 6;

        Characterset.characterLore = 0;
        Characterset.characterLuck = 4;

        Characterset.MaxFocus = 1;
        Characterset.characterFocus = 1;

        Characterset.MinDiceSucc = 5;

        Characterset.money = 9;
        Characterset.clue = 0;

        Characterset.currentLocal_Id = 9900521;

        Characterset.SheetImage = Resources.Load<Sprite>("Sheet/BobJenkins");
    }
}
