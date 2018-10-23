using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaincameraController : MonoBehaviour {

    public GameObject target;

    private Character characterCont; 
    private Vector3 offset;

    public static MaincameraController instance = null;

    private void Awake()
    {
        instance = this;
    }

    void Start () {
        target = GameObject.Find("character");

        characterCont = target.GetComponent<Character>();

        offset = transform.position - target.transform.position;
    }
	
    // LateUpdate에서 GetComponent<> 사용 x, 변수에 저장해서 쓰는 형식으로 바꿈 
	void LateUpdate () {
        /*
        if (characterCont.characterState == Character.State.MOVE)
            transform.position = target.transform.position + offset;
        else if (characterCont.movingDirection == 1)
            transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        */
        /*if (Character.instance.characterState == Character.State.MOVE || GameManager.instance.gameState == GameManager.GameState.Encounter)
        {
            transform.position = target.transform.position + offset;
        }
        */
        transform.position = target.transform.position + offset;
        if (GameManager.instance.gameState==GameManager.GameState.Mythos)
        {
            transform.position = target.transform.position + offset;
        }
        
    }

    public void SetPosition(Vector3 pos)
    {
        transform.position = pos + offset;
    }

    public void ChangeTarget(GameObject _target)
    {
        target = _target;
    }
}
