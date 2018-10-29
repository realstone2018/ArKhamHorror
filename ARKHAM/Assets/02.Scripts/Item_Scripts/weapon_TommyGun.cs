using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_TommyGun : ItemCard {


    public weapon_TommyGun(string _ItemName, int _price, int _hand, ItemKind _ItemKind, ItemType _itemType, Sprite _ItemImage, string _ItemText)
        : base(_ItemName, _price, _hand, _ItemKind, _itemType, _ItemImage, _ItemText)
    {    }


    public override void ItemFuntion()
    {
        Character.instance.powerOfWeapon += 6;
    }

}
