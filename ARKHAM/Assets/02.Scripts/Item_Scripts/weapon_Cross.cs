using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_Cross : ItemCard {

    public weapon_Cross(string _ItemName, int _price, int _hand, ItemKind _ItemKind, ItemType _itemType, Sprite _ItemImage, string _ItemText)
        : base(_ItemName, _price, _hand, _ItemKind, _itemType, _ItemImage, _ItemText)
    {

    }


    public override void ItemFuntion()
    {
        if (Character.instance.nowHand + hand < 3)
        {
            if (!useCheck)
            {
                Character.instance.PhysicalCombat += 0;
                Character.instance.MagicalCombat += 1;
                useCheck = true;
                Character.instance.nowHand += hand;
            }

            else
            {
                Character.instance.PhysicalCombat -= 0;
                Character.instance.MagicalCombat -= 1;
                useCheck = false;
                Character.instance.nowHand -= hand;
            }
        }
       
    }

}
