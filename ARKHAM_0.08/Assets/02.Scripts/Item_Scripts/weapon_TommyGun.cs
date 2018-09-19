using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_TommyGun : ItemList
{
    public weapon_TommyGun(int _ItemId, string _name, int _CheckNum, int _WeaponType, string _ItemText, int _price, int _HandNum, Sprite _ItemImage)
: base(_ItemId,_name,_CheckNum,_WeaponType,_ItemText,_price,_HandNum,_ItemImage)
    {

    }
        
    public override void ItemEvent()
    {
        Character.instance.characterFight += 4;
    }

}
