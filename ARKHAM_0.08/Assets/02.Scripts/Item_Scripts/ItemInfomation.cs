using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemInfomation : MonoBehaviour {

    public int ItemId; //아이템 고유 값
    public enum CardKind {Common, Unique, Spell, Special};  //카드 타입
    public CardKind Type1;
    public enum ItemType { nomal, book, weapon };    //아이템 타입
    public ItemType Type2;
    public int WeaponType; //0 무기아님 1 물리 2 마법
    public string name;    //이름
    public string ItemText;    // 설명
    public int Price;  //아이템 가격
    public int Handnum; //한손 두손
    public Sprite ItemImage; //아이템 이미지

    public bool usecheck; 

    protected abstract void ItemFuntion();

}
