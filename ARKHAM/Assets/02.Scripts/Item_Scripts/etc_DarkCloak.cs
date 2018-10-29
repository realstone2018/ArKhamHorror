using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class etc_DarkCloak : ItemCard {
    
    public etc_DarkCloak(string _ItemName, int _price, int _hand, ItemKind _ItemKind, ItemType _itemType, Sprite _ItemImage, string _ItemText)
        : base(_ItemName, _price, _hand, _ItemKind, _itemType, _ItemImage, _ItemText)
    {

    }

    public override void ItemFuntion()
    {
        Character.instance.evade += 1;
    }

}
