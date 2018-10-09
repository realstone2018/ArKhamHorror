using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceBetween : MonoBehaviour {

    // Street간의 거리만 배열에 저장 
    [SerializeField]
    private int[,] distanceArr = new int[9, 9] {{0, 1, 2, 1, 2, 2, 3, 3, 4},
                                                {1, 0, 1, 1, 2, 2, 3, 3, 4},
                                                {2, 1, 0, 2, 1, 3, 2, 4, 3},
                                                {1, 1, 2, 0, 1, 1, 2, 2, 3},
                                                {2, 2, 1, 1, 0, 2, 1, 3, 2},
                                                {2, 2, 3, 1, 2, 0, 1, 1, 2},
                                                {3, 3, 2, 2, 1, 1, 0, 2, 1},
                                                {3, 3, 4, 2, 3, 1, 2, 0, 1},
                                                {4, 4, 3, 3, 2, 2, 1, 1, 0}};

    public static DistanceBetween instance = null;

    private void Awake()
    {
        instance = this;
    }


    public int GetDistance(int from, int to)
    {
        int row = from / 10;
        int column = to / 10;
        int distance = distanceArr[row, column];

        int caseNum = SortCase(from, to);

        // Street간의 거리는 배열 값 그대로를 가진다.  
        // Local간의 거리는 각 Local을 포함하는 Street 사이의 거리 + 2
        // Street와 Local간의 거리는 +1
        switch (caseNum)
        {
            case 0:
                return distance;
            case 1:
                return (distance + 2);
            case 2:
                return (distance + 1);
            default:
                return -1;
        }
    }


    private int SortCase(int _from, int _to)
    {
        // 거리의 id는 10, 20 ~   십의 단위
        bool fromIsStreet = (_from % 10 == 0) ? true : false; 
        bool toIsStreet = (_to % 10 == 0) ? true : false ;

        // 둘다 거리 일 때
        if (fromIsStreet && toIsStreet)
            return 0;
        // 둘다 지역 일 때
        else if (!fromIsStreet && !toIsStreet)
            return 1;
        // 거리1, 지역1 일 때 
        else if (!fromIsStreet || !toIsStreet)
            return 2;
        else
            return -1;
    }
}

