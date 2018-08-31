using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Local : MonoBehaviour {

    public int local_Id = 0000000;    //장소아이디  맨앞 두자리 99=아컴지역 이외다른세계, 다음 3자리 004=인접한거리 번호 00=장소번호
    public Vector3 position;   //장소 좌표값
    public int[] allowLocal_Id;    //이동가능한 id값배열
    public string eventText;

    public string localFunction;

    public static Character character;

    void Awake()
    {
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

    public virtual void EventResult() { }
}
