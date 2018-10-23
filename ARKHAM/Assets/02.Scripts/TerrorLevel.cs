using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerrorLevel : MonoBehaviour {

    public int terrorlevel = 0;
    public Text levelText;
    public GameObject levelThreeObj;
    public GameObject levelSixObj;
    public GameObject levelNineObj;
    public GameObject levelTenObj;

    public static TerrorLevel instance = null;

    private void Awake()
    {
        instance = this;
    }

    public void TerrorLevelUp()
    {
        terrorlevel++;
        levelText.text = "공포수치 : " + terrorlevel;

        Debug.Log("공포수치가 한단계 올라갑니다");

        if (terrorlevel == 3)
            LevelThree();
        else if (terrorlevel == 6)
            LevelSix();
        else if (terrorlevel == 9)
            LevelNine();
        else
            return;
    }

    // 잡화점이 문을 닫음 
    public void LevelThree()
    {
        Debug.Log("공포수치 3단계 : 잡화점이 문을 닫습니다.");
        levelThreeObj.GetComponent<Image>().color = new Color(0.72f, 0.51f, 1.0f);


    }

    // 골동품 상점이 문을 닫음
    public void LevelSix()
    {
        Debug.Log("공포수치 6단계 : 골동품 상점이 문을 닫습니다.");
        levelSixObj.GetComponent<Image>().color = new Color(0.72f, 0.51f, 1.0f);


    }

    // 마법상점이 문을 닫음 
    public void LevelNine()
    {
        Debug.Log("공포수치 9단계 : 마법상점이 문을 닫습니다.");
        levelNineObj.GetComponent<Image>().color = new Color(0.72f, 0.51f, 1.0f);


    }


    // 공포상태가 10이되면 몬스터가 더이상 외각에 쌓이지 않고 @만큼 몬스터 출현시 보스 출현 
    // 이거 구현시 MonsterControl에서 >= 7인걸 변수로 바꾸기 
    public void LoevelMax()
    {
        Debug.Log("공포수치 10단계 : 더이상 몬스터들이 외각으로 이동하지 않습니다.");
        levelTenObj.GetComponent<Image>().color = new Color(0.72f, 0.51f, 1.0f);


    }
}
