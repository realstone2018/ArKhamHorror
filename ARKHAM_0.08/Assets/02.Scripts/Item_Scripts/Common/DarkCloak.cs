using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkCloak : ItemInfomation {

	void Start () {

        ItemId = 1; //아이템 고유 값
        Type1 = CardKind.Common;
        Type2 = ItemType.weapon;    //아이템 타입
        WeaponType = 0; //0 무기아님 1 물리 2 마법
        name = "어두운망토";    //이름
        ItemText = "회피 체크 +1";    // 설명
        Price = 2;  //아이템 가격
        Handnum = 0; //한손 두손
        ItemImage = Resources.Load<Sprite>("Item_Images/weapon-TommyGun"); //아이템 이미지
        usecheck = false;

    }

    protected override void ItemFuntion()
    {
        Character.instance.characterSneak += 1;
        //Character 스크립트에 회피 변수 추가해주기까지 임시로 은둔에 더해줌
    }
}
