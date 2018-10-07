using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterController : MonoBehaviour {
    
    public Monster monsterPrefab;
    public Local library;

    public List<Monster> monsters = new List<Monster>();
    MonsterMoveController moveController;

    public static MonsterController instance = null;


    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        moveController = FindObjectOfType<MonsterMoveController>();

        CreateMonster(library);
    }


    public void CreateMonster(Local local)
    {
        // 우선은 지정 생성,  후에 랜덤생성으로 변경 예정 
        Monster dictionaryMon = MonsterDictionary.instance.RandomMonster();
        
        Monster instanceMon = Instantiate(monsterPrefab, Vector3.zero, Quaternion.Euler(0, 0, 0));
        instanceMon.transform.parent = local.transform;
        instanceMon.transform.localPosition = new Vector3(0, -1, 1);

        instanceMon.CopyValue(ref dictionaryMon);

        // 이미지를 Resources파일에서 가져옴
        Texture monsterTexture = Resources.Load<Texture>("MonsterImages/" + instanceMon.name);
        instanceMon.GetComponent<MeshRenderer>().material.mainTexture = monsterTexture;

        monsters.Add(instanceMon);
    }


    //차원문 충돌 시 몬스터 출현 함수 
    // 충돌난 곳부터 몬스터를 생성,  그후엔 랜덤으로 
    public void AAA()
    {
        /* 대충 이런 릐양스 
        Gate[] gates = FindObjectsOfType<Gate>();

        for (int i = 0; i < gates.Length; i++)
        {
            CreateMonster(gates[i].createdLocal);
        }
        */
    }


    public void MoveMonster(Monster.Simbol _simbol, MonsterMoveController.Color color)
    {
        for (int i = 0; i < monsters.Count; i++)
        {
            if (monsters[i].simbol == _simbol)
            {
                moveController.MoveEachType(monsters[i], color);
            }
        }
    }
}
