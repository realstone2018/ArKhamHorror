using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaincameraController : MonoBehaviour
{
    public float zoom = 1;
    public float speed = 10;
    public Vector3 MouseStart;
    public GameObject target;

    private Character characterCont;
    private Vector3 offset;

    public static MaincameraController instance = null;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        target = GameObject.Find("character");

        characterCont = target.GetComponent<Character>();

        offset = transform.position - target.transform.position;
    }

    // LateUpdate에서 GetComponent<> 사용 x, 변수에 저장해서 쓰는 형식으로 바꿈 
    void LateUpdate()
    {
        
        if (characterCont.characterState == Character.State.MOVE)
            transform.position = target.transform.position + offset;
        else if (characterCont.movingDirection == 1)
            transform.Translate(Vector3.up * Time.deltaTime, Space.World);

        /*if (Character.instance.characterState == Character.State.MOVE || GameManager.instance.gameState == GameManager.GameState.Encounter)
        {
            transform.position = target.transform.position + offset;
        }
        */
        moveObject();
        if (GameManager.instance.gameState == GameManager.GameState.Mythos)
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
    void moveObject()
    {

        if (Input.GetMouseButtonDown(1))
        {
            MouseStart = new Vector3(Input.mousePosition.x, transform.position.y, Input.mousePosition.y);
            MouseStart = Camera.main.ScreenToWorldPoint(MouseStart);
            MouseStart.y = transform.position.y;

        }
        else if (Input.GetMouseButton(1))
        {
            var MouseMove = new Vector3(Input.mousePosition.x, transform.position.y, Input.mousePosition.y);
            MouseMove = Camera.main.ScreenToWorldPoint(MouseMove);
            MouseMove.y = transform.position.y;
            transform.position = transform.position - (MouseMove - MouseStart);

        }


        else
        {
            float keyHorizontal = Input.GetAxis("Horizontal");

            float keyVertical = Input.GetAxis("Vertical");

            transform.Translate(Vector3.right * speed * Time.smoothDeltaTime * keyHorizontal, Space.World);

            transform.Translate(Vector3.up * speed * Time.smoothDeltaTime * keyVertical, Space.World);

            transform.position -= (transform.position - target.transform.position) * Input.GetAxis("Mouse ScrollWheel") * zoom;

        }
    }


}