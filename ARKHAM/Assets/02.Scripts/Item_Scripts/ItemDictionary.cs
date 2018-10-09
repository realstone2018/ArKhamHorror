using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ItemDictionary : MonoBehaviour {


    public List<ItemCard> CommonItemDeck;
    public List<ItemCard> UniquItemDeck;


    public static ItemDictionary instance = null;


    void Awake()
    {
        CommonItemDeck = new List<ItemCard>();
        UniquItemDeck = new List<ItemCard>();

        instance = this;
        
        CommonItemDeck.Add(new weapon_TommyGun("토미건", 7, 2, ItemCard.ItemKind.CommonItem, ItemCard.ItemType.Physical,Resources.Load<Sprite>("Item_Images/weapon-TommyGun"), "전투 체크 +6"));
        CommonItemDeck.Add(new weapon_18Derringer("18구경 데린저",3,1, ItemCard.ItemKind.CommonItem, ItemCard.ItemType.Physical, Resources.Load<Sprite>("Item_Images/weapon-18Derringer"), "전투 체크 +2  의도적으로 버리지 않는 한 이 카드는 잃어버리거나 도둑맞지 않습니다."));
        CommonItemDeck.Add(new book_AncientTome("고대문서", 4, 0, ItemCard.ItemKind.CommonItem, ItemCard.ItemType.Book, Resources.Load<Sprite>("Item_Images/book-AncientTome"), "이동 단계: 이동력 2를 쓰고 이 카드를 고갈시킨 다음 지식 체크(-1)를 합니다.성공하면 이 카드를 버리고 마법주문 카드 1장을 얻습니다.실패하면 아무 일도 일어나지 않습니다."));
        CommonItemDeck.Add(new etc_DarkCloak("어두운 망토", 2, 0, ItemCard.ItemKind.CommonItem, ItemCard.ItemType.Nomal, Resources.Load<Sprite>("Item_Images/etc-DarkCloak"), "회피 체크 +1"));
        CommonItemDeck.Add(new weapon_Cross("십자가", 3, 1, ItemCard.ItemKind.CommonItem, ItemCard.ItemType.Magical,Resources.Load<Sprite>("Item_Images/weapon-cross"), "전투 체크 +0 (언데드 괴물을 상대할 때는 + 3)  공포 체크 + 1"));

        //Debug.Log("배열 할당 갯수"+CommonItemDeck.Count);
        //Debug.Log(CommonItemDeck[1].ItemName);

        UniquItemDeck.Add(new book_BookOfDzyan("드잔서", 3, 0, ItemCard.ItemKind.UniquItem, ItemCard.ItemType.Book, Resources.Load<Sprite>("Item_Images/book-BookOfDzyan"), "이동 단계: 이동력 2를 쓰고 이 카드를 고갈시킵니다. 지식 체크(-1)를 합니다. 성공하면 마법주문 카드 1장을 얻습니다. 정신력 1을 잃은 다음 이 카드 위에 사용하지 않은 체력 마커 1개를 올려놓습니다. 이 카드 위에 체력 마커가 2개째 놓이면 이 카드를 버립니다. 실패하면 아무 일도 일어나지 않습니다."));
        UniquItemDeck.Add(new book_TheKingInYellow("황색의 왕", 2, 0, ItemCard.ItemKind.UniquItem, ItemCard.ItemType.Book, Resources.Load<Sprite>("Item_Images/book-TheKingInYellow"), "이동 단계: 이동력 2를 쓰고 이 카드를 고갈시킵니다. 지식 체크(-2)를 합니다. 성공하면 단서 마커 4개를 얻습니다. 정신력 1을 잃고 이 카드를 버립니다. 실패하면 아무 일도 일어나지 않습니다."));
        UniquItemDeck.Add(new etc_AlienStatue("외계조각상",5, 0, ItemCard.ItemKind.UniquItem, ItemCard.ItemType.Nomal, Resources.Load<Sprite>("Item_Images/etc-AlienStatue"), "이동 단계: 이동력 2를 쓰고 정신력 1을 낸 다음 이 카드를 고갈시킵니다. 그리고 주사위 1개를 굴립니다. 성공하면 마법주문 카드 1장이나 단서 마커 3개를 얻습니다. 실패하면 체력 2를 잃습니다."));
        UniquItemDeck.Add(new etc_HealingStone("치유석", 8, 0, ItemCard.ItemKind.UniquItem, ItemCard.ItemType.Nomal, Resources.Load<Sprite>("Item_Images/etc-HealingStone"), "유지 단계: 이 카드를 고갈시키고 정신력이나 체력 1을 회복합니다. 고대의 존재가 깨어나면 이 카드를 버립니다."));


    }

    public void DrowOneCard(int i)
    {
        int num = i;
        if (num == 1)
        {
            
            Character.instance.CharacterInventory.Add(CommonItemDeck[0]);
            CommonItemDeck.RemoveAt(0);

        }
        if (num == 2)
        { 
            Character.instance.CharacterInventory.Add(UniquItemDeck[0]);
            UniquItemDeck.RemoveAt(0);
        }
        //마법 아이템 추가
    }

}
