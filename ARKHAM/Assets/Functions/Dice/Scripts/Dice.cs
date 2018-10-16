using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour {

    Rigidbody rigid;

    // 주사위 각 면에 위치한, Gizmos들의 Position값을 저장한 배열
    public Transform[] gizmoPositions;
    // 최종 주사위 값 
    public int result;

    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();   
    }

    // 프리팹을 생성시  생성시 설정 각도랑 OnEnable각도랑 어떤게 적용되려나
    void OnEnable()
    {
        //gameObject.transform.position = initPosition;
        gameObject.transform.eulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
    }

    public void ThrowDice() {
        rigid.isKinematic = false;
        rigid.AddForce(10.0f, 5.0f, 0f, ForceMode.Impulse);

        Invoke("CheckDiceMoving", 3.0f);
    }

    // IsSleeping() : 물리 연산이 없을 때 true 반환    
    // 주사위가 던저지기 전에도 물리연산이 없으므로 높이가 1.5이하일 때를 and로 
    // 주사위가 5.5초가 지난 후에도 움직이고 있으면 1초후 다시 호출 
    void CheckDiceMoving()
    {
        if (gameObject.GetComponent<Rigidbody>().IsSleeping() && transform.position.y <= 1.5f)
            CompareValusHeight();
        else
        {
            Invoke("CheckDiceMoving", 1.0f);
        }
    }

    void CompareValusHeight()
    {
        float maxHeight = 0;

        for (int i = 0; i < gizmoPositions.Length; i++)
        {
            if (gizmoPositions[i].position.y > maxHeight)
            {
                maxHeight = gizmoPositions[i].position.y;
                result = i + 1;
            }
        }

        DiceController.instance.AddDiceValue(result);
    }
}
