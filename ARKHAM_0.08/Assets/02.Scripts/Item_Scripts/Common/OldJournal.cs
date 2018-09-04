using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldJournal : ItemInfomation {

	
	void Start () {
        ItemId = 2; //아이템 고유 값
        Type1 = CardKind.Common;
        Type2 = ItemType.book;    //아이템 타입
        WeaponType = 0; //0 무기아님 1 물리 2 마법
        name = "고대문서";    //이름
        ItemText = "이동 단계: 이동력 2를 쓰고 이 카드를 고갈시킨 다음 지식 체크(-1)를 합니다. 성공하면 이 카드를 버리고 마법주문 카드 1장을 얻습니다. 실패하면 아무 일도 일어나지 않습니다.";    // 설명
        Price = 4;  //아이템 가격
        Handnum = 0; //한손 두손
        ItemImage = Resources.Load<Sprite>("Item_Images/book-OldJournal"); //아이템 이미지
        usecheck = false;
    }

    protected override void ItemFuntion()
    {
        if(Character.instance.maxMoveCount-Character.instance.currentMoveCount>2)
        {
            Character.instance.currentMoveCount -= 2;
            
            //지식체크 후 성공여부 판단 이벤트진행

        }
         
    }

}
