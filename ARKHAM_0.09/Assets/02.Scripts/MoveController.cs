 using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;


public class MoveController : MonoBehaviour
{
    // 인스펙터상에서 값조정 할 수 있게 public으로 바꿈 
    public float speed = 3f;   //속도   

    static public MoveController instance;

    private void Awake()
    {
        instance = this;
    }

    public IEnumerator MovePosition(Vector3 position)
    {
        Vector3 goalPosition = new Vector3(position.x, 1.2f, position.z);

        while (Vector3.Distance(goalPosition, transform.position) != 0f) {

            transform.position = Vector3.MoveTowards(transform.position, goalPosition, speed * Time.deltaTime); //현재 캐릭터 정보에있는 위치와 이동해야될 위치를 보고 직선으로 이동 

            yield return new WaitForSeconds(0.01f);
        }

        if (gameObject.GetComponent<Character>())
        {
            gameObject.GetComponent<Character>().MoveComplete();
        }
    }



}
