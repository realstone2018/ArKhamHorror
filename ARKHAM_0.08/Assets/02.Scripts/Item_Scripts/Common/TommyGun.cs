using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TommyGun : ItemInfomation {


    public TommyGun()
    {

    }

    void Start()
    {
        ItemId = 1; //아이템 고유 값
        Type1 = CardKind.Common;
        Type2 = ItemType.weapon;    //아이템 타입
        WeaponType = 1; //0 무기아님 1 물리 2 마법
        name = "토미건";    //이름
        ItemText = "전투 체크 +6";    // 설명
        Price = 7;  //아이템 가격
        Handnum = 2; //한손 두손
        ItemImage = Resources.Load<Sprite>("Item_Images/weapon-TommyGun"); //아이템 이미지
        usecheck = false;
    }

    protected override void ItemFuntion()
    {
        Character.instance.characterFight += 6;
        //임시로 투지에 플러스 해줌 추후 character스크립트에 combat 변수추가후 몬스터 전투에 사용으로 바꿈
    }

}
