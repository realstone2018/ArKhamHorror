using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {

    public Monster monsterPrefab;
    public Local library;

    void Start()
    {
        CreateMonster(library);
    }

    public void CreateMonster(Local local)
    {
        // 우선은 지정 생성,  후에 랜덤생성으로 변경 예정 
        Monster dictionaryMon = MonsterDictionary.instance.SearchMonster("Ghost");
        
        Monster instanceMon = Instantiate(monsterPrefab, Vector3.zero, Quaternion.Euler(0, 0, 0));
        instanceMon.transform.parent = local.transform;
        instanceMon.transform.localPosition = new Vector3(0, -1, 1);

        instanceMon.CallValue(ref dictionaryMon);
    }

}
