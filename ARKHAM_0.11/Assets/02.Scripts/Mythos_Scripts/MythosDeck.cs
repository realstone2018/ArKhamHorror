using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
    
public class MythosDeck : MonoBehaviour {

    string explain;
    string title;
    Mythos.MythosType mythosType;
    List<Monster.Simbol> whiteSimbol = new List<Monster.Simbol>();
    List<Monster.Simbol> blackSimbol = new List<Monster.Simbol>();

    public List<Mythos> mythosDeck;

    void Awake()
    {
        mythosDeck = new List<Mythos>();

        /* 문자열을 이용해 컴포넌트 동적 할당 
        mythosDec[0] = "AllQuitInArkham";
        mythosDec[1] = "BigStormSweepsArkham";
        mythosDec[2] = "BlueFlu";   
        
        Type type = Type.GetType(mythosDec[1]);
        eventCard.AddComponent(type);
        */

        //////////////////////  HeadLine //////////////////////////////
        mythosType = Mythos.MythosType.HeadLine;


        title = "AllQuitInArkham";
        explain = "각 플레이어는 행운체크(-1), 성공 시 축복카드 획득";
        whiteSimbol.Add(Monster.Simbol.Hexagon);
        blackSimbol.Add(Monster.Simbol.BackSlash);
        blackSimbol.Add(Monster.Simbol.Triangle);
        blackSimbol.Add(Monster.Simbol.Star);
        // 각 값은 존재하나 컴포넌트가 아니므로 인스펙터상에 x , 컴포넌트가 아니므로 컴파일x, start()문에서 값 초기화시 값이 입력되지 x
        mythosDeck.Add(new AllQuitInArkham(title, explain, "Local_woods", "Local_HistoricalSo", mythosType, whiteSimbol, blackSimbol));


        title = "BlueFlu";
        explain = "감옥에 수감된 모든 플레이어들은 풀려납니다.";
        // Simbol이 위와 동일 
        mythosDeck.Add(new BlueFlu(title, explain, "Local_Unnameable", "Local_woods", mythosType, whiteSimbol, blackSimbol));

        //blackSimbol.Clear();
        //whiteSimbol.Clear();

        title = "BigStormSweepsArkham";
        explain = "하늘과 교외에 있는 모든 몬스터들이 주머니로 돌아갑니다.";
        whiteSimbol.Add(Monster.Simbol.Moon);
        blackSimbol.Add(Monster.Simbol.Cross);
        mythosDeck.Add(new BigStormSweepsArkham(title, explain, "Local_IndefendenceSQ", "Local_Unnameable", mythosType, whiteSimbol, blackSimbol));

        Suffle();
    }


    public Mythos DrawCard()
    {
        //Mythos _mythos = mythosDeck[0];
        //eventCard.GetComponent<Mythos>().CopyValue(ref _mythos);

        mythosDeck.Add(mythosDeck[0]);
        mythosDeck.Remove(mythosDeck[0]);

        return mythosDeck[0];
    }


    // 디버깅용 함수
    public void ShowAll()
    {
        for(int i = 0; i < mythosDeck.Count; i++)
        {
            Debug.Log("mythosDeck[" + i + "] : " + mythosDeck[i].explain);
        }
    }

    // 알고리즘에 순서변경알고리즘 대체 
    public void Suffle()
    {
        int num = mythosDeck.Count;

        for (int i = 0; i < num; i++)
        {
            int k = UnityEngine.Random.Range(i, num);

            Mythos value = mythosDeck[i];
            mythosDeck[i] = mythosDeck[k];
            mythosDeck[k] = value;
        }
    }


    // 처음 신화는 소문이 아닌 카드를 뽑을 때 까지 Draw()
    public void FindNotRumor()
    {

        Debug.Log("FindNotRumor");
        while(mythosDeck[0].mythosType == Mythos.MythosType.Rumor)
        {
            mythosDeck.Add(mythosDeck[0]);
            mythosDeck.Remove(mythosDeck[0]);
        }
    }
}
