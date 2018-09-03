using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Local_Livrary : Local {

    public int activeEvent = 0;

    void Start ()
    {
        local_Id = 9900410;   //99=아컴지역 004=인접한거리(1번,3번,6번) 10=장소번호
        allowLocal_Id = new int[1];
        allowLocal_Id[0] = 9913694;

        position = transform.position;
    }

    protected override void EventOne()
    {

        eventText = "도서관의 그림자 진 구석에 있는 책 하나가 당신에게 공포스러운 뭔가를 속삭였습니다. 정신력 1을 잃습니다.";
        Character.instance.characterSanity -= 1;
    }

    protected override void EventTwo()
    {
        activeEvent = 2;
        eventText = "눈을 들어보니 아비게일 포맨이 엉덩이에 손을 얹고 불만스러운 표정으로 당신을 향해 몸을 구부리고 있었습니다. 의지 체크(-1)를 합니다. 성공하면 그가 당신이 찾던 책을 찾는 것을 도와줍니다. 특별아이템 카드더미를 펼치다가 첫 번째 서적카드를 얻습니다. 실패하면 도서관에서 너무 떠들었다는 이유로 도서관 밖으로 쫓겨납니다. 미스캐토닉 대학의 거리로 이동합니다.";
        DiceController.instance.SetDiceThrow(this, (Character.instance.characterWILL-1), Character.instance.MinDiceSucc, 6);


    }

    protected override void EventThree()
    {
        activeEvent = 3;
        eventText = "의지 체크(+0)를 하고 아래와 같은 결과를 얻습니다." +
            "성공한 주사위수" +
            "0 ) 아비게일이 당신을 내쫓습니다. 미스캐토닉 대학의 거리로 이동합니다." +
            "1 ) 아비게일이 당신을 도서관의 개인 열람실로 들여보냅니다. 이곳에서 고대 서적을 발견할 수 있습니다. 마법주문카드 2장을 뽑아 그중 1장을 얻습니다." +
            "2 +) 아비게일이 도서관 진열장에 있는 특이한 물품 하나를 빌려줍니다. 특별 아이템 카드 1장을 얻습니다.";
        DiceController.instance.SetDiceThrow(this, (Character.instance.characterWILL ), Character.instance.MinDiceSucc, 6);

    }

    protected override void EventFour()
    {

    }

    protected override void EventFive()
    {

    }

    protected override void EventSiz()
    {

    }

    protected override void EventSeven()
    {

    }

    public override void EventResult(int _successCount)
    {
        int successCount = _successCount;


        switch (activeEvent)
        {
            case 1:
                if (successCount == 0)
                    Character.instance.characterStamina += 1;
                else if (successCount > 0)
                {
                    /*DiceController.instance.SetDiceThrow(this, 1, Character.instance.MinDiceSucc, 6);
                    diceNum = DiceController.instance.diceValues;
                    for(int i = 0; i<6;i++)
                    {
                        if (diceNum[i] == 1)
                            Character.instance.characterStamina += i;
                    }*/
                    //주사위랑 결과부분 분리 요망
                    //주사위에서 결과를 호출해서 주사위가 계속 반복됨
                    //주사위 굴려 나온 숫자만큼 체력증가

                }
                break;
            case 2:
                if (successCount == 0)
                {
                    StartCoroutine(MoveController.instance.MovePosition(GameObject.Find("Miskatonic_U").GetComponent<Transform>().position));
                }
                else if (successCount >1)
                {
                    Debug.Log("특별아이템 서적 획득");
                    ////////////////특별아이템 획득 이벤트
                }
                break;
            case 3:
                Debug.Log("마법주문 획득 이벤트");
                //구현해야됨
                if (successCount == 0)
                {
                    StartCoroutine(MoveController.instance.MovePosition(GameObject.Find("Miskatonic_U").GetComponent<Transform>().position));
                }
                else if(successCount ==1)
                {
                    Debug.Log("마법 주문 획득 이벤트");
                    //마법주문 획득이벤트 2개중 택1
                }
                else if(successCount > 1)
                {
                    Debug.Log("특별아이템 1개 획득 이벤트");
                    //특별아이템 획득이벤트
                }
                break;
        }
    }
}
