using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    }

    private void FlyMove()
    {
        Debug.Log("Move FlyMove");

    }

    private void FixeMove()
    {
        Debug.Log("Move FixeMove");

    }

    private void SMovement()
    {
        Debug.Log("Move SMovement");

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
