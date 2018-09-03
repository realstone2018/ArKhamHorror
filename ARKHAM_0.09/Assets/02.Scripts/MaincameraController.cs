using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaincameraController : MonoBehaviour {

    public GameObject character;

    private Character characterCont; 
    private Vector3 offset;
	
	void Start () {
        offset = transform.position - character.transform.position;
        characterCont = character.GetComponent<Character>();
    }
	
    // LateUpdate에서 GetComponent<> 사용 x, 변수에 저장해서 쓰는 형식으로 바꿈 
	void LateUpdate () {
        if (characterCont.movingCheck)
            transform.position = character.transform.position + offset;
        else if (characterCont.movingDirection == 1)
            transform.Translate(Vector3.up * Time.deltaTime, Space.World);
    }
}
