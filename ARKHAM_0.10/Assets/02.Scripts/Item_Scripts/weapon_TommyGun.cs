using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_TommyGun : ItemCard {


    public weapon_TommyGun(string _ItemName, int _price, int _hand, ItemKind _ItemKind, ItemType _itemType, Sprite _ItemImage, string _ItemText)
        : base(_ItemName, _price, _hand, _ItemKind, _itemType, _ItemImage, _ItemText)
    {
        Debug.Log("토미건 입력");
    }


    public override void ItemFuntion()
    {
        Character.instance.PhysicalCombat += 6;
    }

}
