using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Local : MonoBehaviour {

    public int local_Id;   
    public Vector3 position;   //장소 좌표값
    public int[] allowLocal_Id;    //이동가능한 id값배열
    public string eventText;

    public string localFunction;

    public int whitePath_id = 0;
    public int blackPath_id = 0;

    // 부모의 static 함수에서만 사용하므로 private
    private static Local[] locals;

    // 가상함수에서 사용함으로 Protected
    protected static Character character;

    void Start()
    {
        locals = FindObjectsOfType<Local>();

        character = GameObject.Find("character").GetComponent<Character>();
    }


    private void OnMouseDown()
    {
        foreach (int local_Id in allowLocal_Id)
        {
            if (local_Id == character.currentLocal_Id)
            {
                Vector3 goalPosition = new Vector3(transform.position.x, 1, transform.position.z);
                character.StartMove(goalPosition);
            }
        }
    }

    // static함수는 객체가 상속되도 하나만 존재하며,  싱글턴없이 바로 함수 호출 가능 Local.GetLocalObjById( .. );
    public static Local GetLocalObjById(int id)
    {
        foreach (Local local in locals)
        {
            if (local.local_Id == id)
                return local;
        }

        return null;
    }


    public void ActiveEvent(int num)
    {
        switch (num)
        {
            case 1:
                EventOne();
                break;
            case 2:
                EventTwo();
                break;
            case 3:
                EventThree();
                break;
            case 7:
                EventSeven();
                break;
            default:
                Debug.Log("ActiveEventFalse");
                break;
        }

        //LocalEventController.instance.SetMessage(eventText);
    }

    protected abstract void EventOne();

    protected abstract void EventTwo();

    protected abstract void EventThree();

    protected abstract void EventFour();

    protected abstract void EventFive();

    protected abstract void EventSiz();

    protected abstract void EventSeven();

    public virtual void EventResult(int n) { }
}
