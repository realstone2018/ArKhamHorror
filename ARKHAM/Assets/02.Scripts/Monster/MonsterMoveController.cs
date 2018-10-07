using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// 몬스터 스크립트에도 추가되넉있음  같이 이동하기
// 몬스터 스크립트에도 추가되넉있음  같이 이동하기
// 몬스터 스크립트에도 추가되넉있음  같이 이동하기
// 몬스터 스크립트에도 추가되넉있음  같이 이동하기

public class MonsterMoveController : MonoBehaviour {

    public Monster monster;
    public Local currentLocal;
    public Local goalLocal;

    Local[] locals;

    public enum Color { White, Black };
    Color color;


    private void Start()
    {
        locals = FindObjectsOfType<Local>();
    }


    public void MoveEachType(Monster _monster, Color _color)
    {
        Debug.Log(_monster + "MoveEachType");

        monster = _monster;
        Monster.Type type = monster.type;
        color = _color;

        switch(type)
        {
            case Monster.Type.Normal:
                NormalMove();
                break;
            case Monster.Type.Fast:
                FastMove();
                break;
            case Monster.Type.Fly:
                FlyMove();
                break;
            case Monster.Type.Fixed:
                FixeMove();
                break;
            case Monster.Type.SMovement:
                SMovement();
                break;
        }
    }


    private void NormalMove()
    {
        Debug.Log(monster + "Move Normal");

        currentLocal = monster.GetComponentInParent<Local>();


        // 지역에서 거리로
        if (currentLocal.allowLocal_Id.Length == 1)
        {
            Debug.Log("From Local to Street");

            goalLocal = FindLocalById(currentLocal.allowLocal_Id[0]);
            
            StartCoroutine(monster.MovePosition(goalLocal.position));
        }
        // 거리에서 거리로 
        else
        {
            Debug.Log("Local to Local"); 

            if (color == Color.White) {
                goalLocal = FindLocalById(currentLocal.whitePath_id);

                StartCoroutine(monster.MovePosition(goalLocal.position));
            }
            else
            {
                goalLocal = FindLocalById(currentLocal.blackPath_id);

                StartCoroutine(monster.MovePosition(goalLocal.position));
            }
        }

        monster.transform.SetParent(goalLocal.transform);
    }


    private void FastMove()
    {
        Debug.Log("Move FastMove");
        NormalMove();

        // 조사자와 같은 지역에 있을 경우 이동 중지 
        if (!monster.meetPlayer)
            NormalMove();
    }


    private void FlyMove()
    {
        Debug.Log("Move FlyMove");

        // 거리, 지역에 있을때 이동 시 인접한 거리에 있는 조사자 쪽으로, 없으면 하늘로
        // 하늘에서 이동 시 거리에있는 조사자중 은둔수치가 가장 낮은 애한테 바로 이동, 없으면 그대로 

        currentLocal = monster.GetComponentInParent<Local>();


        // 모든 조사자 들을 불러와 거리에있는 조사자만 분리해서 저장
        GameObject[] characters = new GameObject[4];
        List<Character> streetCharacter = new List<Character>();
        characters = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i] != null)
            {
                // 캐릭터가 위치한 지역의 이동가능경로 수를 보고 지역인지 장소인지 판별
                Character c = characters[i].GetComponent<Character>();
                Local local = FindLocalById(c.currentLocal_Id);

                if (local.allowLocal_Id.Length > 1)
                {
                    streetCharacter.Add(c);
                }
            }
        }


        // if(currentLocal == 하늘지역id)
        {
            // 운둔이 가장 낮은놈을 판별 후 그곳으로 이동 
            Character lowSneakChar = streetCharacter[0];

            for (int j = 0; j < streetCharacter.Count; j++)
            {
                if (streetCharacter[j].Sneak < lowSneakChar.Sneak)
                    lowSneakChar = streetCharacter[j];
            }

            goalLocal = FindLocalById(lowSneakChar.currentLocal_Id);
            StartCoroutine(monster.MovePosition(goalLocal.position));
        }
        //else 지역, 거리에있다면 
        {
                // 가장 가까운 조사자 판별을 위해 
        }
    }


    private void FixeMove()
    {
        Debug.Log("Move FixeMove");
        // 이동 없음 아무것도 하지 않는다.
    }


    private void SMovement()
    {
        Debug.Log("Move SMovement");

        // 몬스터의 이름이 HoundofTindalos else Chthonian,  if else문 만들기
        // HoundofTindalos - 이동할 때, 조사자가 있는 아컴의 장소 중 가장 가까운 곳으로 이동한다.(아컴 정신병원과 세인트 메리 병원은 제외)
        // Chthonian - 이동해야 할 때, 이동하지 않고 그 대신 주사위를 1개 굴려 4~6이 나오면 아컴에 있는 모든 조사자는 체력 1을 잃는다.
        if (monster.id == "HoundofTindalos")
        {

        }
        else
        {

        }
    }


    private Local FindLocalById(int id)
    {
        foreach (Local local in locals)
        {
            if (local.local_Id == id)
                return local;
        }

        return null;
    }
}
