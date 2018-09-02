using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemList : MonoBehaviour {

	public class Item
    {
        private int ItemId; //처음2자리 아이템타입, 다음2자리 서적,일반,무기 , 다음3자리 식별번호
        private string name;    //이름
        private int CheckNum;    //전투체크,아이템 수치
        private string ItemText;    // 설명
        private int WeaponType; //0 무기아님 1 물리 2 마법
        private int Price;  //아이템 가격
        private int Handnum; //한손 두손
        private Sprite ItemImage; //아이템 이미지
        

        public Item(int _ItemId, string _name, int _CheckNum, int _WeaponType, string _ItemText,int _price,int _HandNum,Sprite _ItemImage)
        {
            this.ItemId = _ItemId;
            this.name = _name;
            this.CheckNum = _CheckNum;
            this.WeaponType = _WeaponType;
            this.ItemText = _ItemText;
            this.Price = _price;
            this.Handnum = _HandNum;
            this.ItemImage = _ItemImage;

        }

		public int getPrice()
		{
			return this.Price;
		}

        public Sprite GetImageAction()
        {
            return this.ItemImage;
        }
        
    }

    public Dictionary<int, Item> NomalItemList;
    public Dictionary<int, Item> MagickItemList;
    public Dictionary<int, Item> UniqueItemList;

    public static ItemList instance = null;

    private void Awake()
    {
        instance = this;

        
        NomalItemList = new Dictionary<int, Item>();
        int num;

        //num = 1001001;  // 10=일반아이템 01= 무기 001 =아이템 식별번호
        num = 1;
        NomalItemList.Add(num, new Item (num,"토미건",6,1,"전투 체크 +6",7,2, Resources.Load<Sprite>("Item_Images/weapon - TommyGun")));

        num = 2;  // 10=일반아이템 02 = 서적 002=아이템 식별번호
        NomalItemList.Add(num, new Item(num, "고대문서", 1, 0, "이동 단계: 이동력 2를 쓰고 이 카드를 고갈시킨 다음 지식 체크(-1)를 합니다. 성공하면 이 카드를 버리고 마법주문 카드 1장을 얻습니다. 실패하면 아무 일도 일어나지 않습니다.", 4,0, Resources.Load<Sprite>("Item_Images/book-OldJournal")));
        //서적아이템 따로구현 요망
        num = 3;  // 10=일반아이템 00=일반 003=아이템식별번호
        NomalItemList.Add(num, new Item(num, "어두운망토", 1, 0, "회피 체크 +1", 2,0, Resources.Load<Sprite>("Item_Images/etc-DarkCloak")));

        //num = 2001001; // 20=마법아이템 01=무기 001=아이템식별번호
        //ItemList.Add(num, new Item(num, "쭈그려트리기", 1, 2, "회피 체크 +1", 2,1));


       
        

        
        MagickItemList = new Dictionary<int, Item>();

        num = 2001001; // 20=마법아이템 01=무기 001=아이템식별번호
        MagickItemList.Add(num, new Item(num, "쭈그려트리기", 1, 2, "회피 체크 +1", 2,1, Resources.Load<Sprite>("Item_Images/weapon - TommyGun")));





        
        UniqueItemList = new Dictionary<int, Item>();

        num = 3001001;  // 30=특별아이템 01=무기 001아이템식별번호
        UniqueItemList.Add(num, new Item(num, "마법 걸린 검", 4, 2, "전투 체크 +4", 6, 1, Resources.Load<Sprite>("Item_Images/weapon-EnchantedBlade")));

        num = 3002002;  // 30=특별아이템 02=서적 002아이템식별번호
        UniqueItemList.Add(num, new Item(num, "드잔서", 1,0, "이동 단계: 이동력 2를 쓰고 이 카드를 고갈시킵니다. 지식 체크(-1)를 합니다. 성공하면 마법주문 카드 1장을 얻습니다. 정신력 1을 잃은 다음 이 카드 위에 사용하지 않은 체력 마커 1개를 올려놓습니다. 이 카드 위에 체력 마커가 2개째 놓이면 이 카드를 버립니다. 실패하면 아무 일도 일어나지 않습니다.", 3,0, Resources.Load<Sprite>("Item_Images/book-BookOfDzyan")));

        num = 3000003;  // 30=특별아이템 00=일반 003아이템식별번호
        UniqueItemList.Add(num, new Item(num, "르리예의 루비", 3, 0, "이동 단계: 이동력 3을 추가로 얻습니다.",8, 0, Resources.Load<Sprite>("Item_Images/book-BookOfDzyan")));


    }


    
}
