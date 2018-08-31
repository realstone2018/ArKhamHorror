using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour
{
    public GameObject dicePrefab;
    // 생성한 주사위들을 저장할 List
    public List<Dice> dices = new List<Dice>();

    public bool readyThrow = false;
    public int diceCount = 0;

    public int[] diceValues;
    private int valueCount = 0;
    private int successCount = 0;
    private int minValue;
    private int maxValue;
    public bool AdditoryDiceValue = false;

    public Local eventLocal;

    public GameObject cameraObj;

    public static DiceController instance = null;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        cameraObj = GameObject.Find("Camera");
    }

    void Update()
    {
        // readyThrow가 true일때만 마우스 클릭에 의해 이벤트 발생 
        if (Input.GetMouseButtonDown(0) && readyThrow)
        {
            for (int i = 0; i < dices.Count; i++)
            {
                dices[i].ThrowDice();
            }

            readyThrow = false;
        }
    }

    public void SetDiceThrow(Local local, int num, int min, int max)
    {
        eventLocal = local;

        diceCount = num;
        minValue = min;
        maxValue = max;

        // 주사위 수가 0이면 더 이상 진행할 필요 x, 배열도 모두 0으로 되있으므로 SuccessOrFailure는 0을 반환 -> 이벤트 실패
        if (diceCount <= 0)
            return;

        for (int i = 0; i < diceCount; i++)
        {
            GameObject instanceDice = Instantiate(dicePrefab, Vector3.zero, Quaternion.Euler(0, 0, 0));
            instanceDice.transform.parent = cameraObj.transform;
            instanceDice.transform.localPosition = new Vector3(i * 2, -4, i * 2 + 6);


            dices.Add(instanceDice.GetComponent<Dice>());
        }

        readyThrow = true;
}


    // 각 주사위로부터 result값을 인자로 받아 통계를 낸다.
    public void AddDiceValue(int value)
    {
        switch (value)
        {
            case 1:
                diceValues[0] += 1;
                break;
            case 2:
                diceValues[1] += 1;
                break;
            case 3:
                diceValues[2] += 1;
                break;
            case 4:
                diceValues[3] += 1;
                break;
            case 5:
                diceValues[4] += 1;
                break;
            case 6:
                diceValues[5] += 1;
                break;
        }
        valueCount++;

        if (diceCount == valueCount && !AdditoryDiceValue)
        {
            Debug.Log("AdditoryDiceValue = false ");
            eventLocal.EventResult();
            return;
        }
        else if (AdditoryDiceValue)
        {
            Debug.Log("AdditoryDiceValue = true");
            DiceController.instance.AdditoryDiceValue = false;
        }
    }

    void ResetDice()
    {
        valueCount = 0;

        for (int i = 0; i < diceValues.Length; i++)
        {
            diceValues[i] = 0;
        }
        
        int count = dices.Count;

        for (int i = 0; i < count; i++)
        {
            Destroy(dices[0].gameObject);
            dices.Remove(dices[0]);
        }

    }


    // 인자로 성공 범위를 받아, 성공한 주사위 수 반환  
    public int SuccessOrFailure()
    {
        successCount = 0;

        for (int i = (minValue -1); i <= (maxValue -1); i++)
        {
            successCount += diceValues[i];
        }

        ResetDice();
        return successCount;
    }

    public int ResultDiceValue()
    { 
        for (int i = 0; i < 6; i++)
        {
            if (diceValues[i] == 1)
            {
                Debug.Log("ResultDiceValue return i : " + i);
                ResetDice();
                return i + 1;
            }
        }

        return 0;
    }


}
