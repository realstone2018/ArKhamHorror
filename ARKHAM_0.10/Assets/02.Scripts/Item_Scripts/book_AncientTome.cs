using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class book_AncientTome : ItemCard {

    public book_AncientTome(string _ItemName, int _price, int _hand, ItemKind _ItemKind, ItemType _itemType, Sprite _ItemImage, string _ItemText)
        : base(_ItemName, _price, _hand, _ItemKind, _itemType, _ItemImage, _ItemText)
    {

    }


    public override void ItemFuntion()
    {
        Debug.Log("이동 단계: 이동력 2를 쓰고 이 카드를 고갈시킨 다음 지식 체크(-1)를 합니다. 성공하면 이 카드를 버리고 마법주문 카드 1장을 얻습니다. 실패하면 아무 일도 일어나지 않습니다.");
        // 이동단계때 정신력 소모 후 체크
    }
}
