using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDeck : MonoBehaviour {

    List<ItemList> CommonItemDeck = new List<ItemList>();



    public static ItemDeck instance = null;

    private void Awake()
    {
        instance = this;

        CommonItemDeck.Add(new ItemList(1, "토미건", 6, 1, "전투 체크 +6", 7, 2, Resources.Load<Sprite>("Item_Images/weapon-TommyGun")));
        CommonItemDeck.Add(new ItemList(2, "고대문서", 1, 0, "이동 단계: 이동력 2를 쓰고 이 카드를 고갈시킨 다음 지식 체크(-1)를 합니다. 성공하면 이 카드를 버리고 마법주문 카드 1장을 얻습니다. 실패하면 아무 일도 일어나지 않습니다.", 4, 0, Resources.Load<Sprite>("Item_Images/book-OldJournal")));
        CommonItemDeck.Add(new ItemList(3,"어두운망토", 1, 0, "회피 체크 +1", 2, 0, Resources.Load<Sprite>("Item_Images/etc-DarkCloak")));
    }

    public ItemList DrowCard(int num)
    {

        return CommonItemDeck[num];
    }

}
