  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //캐릭터스텟
    public int Sanity = 5;
    public int characterSanity { get { return Sanity; } set { Sanity = value; } }
    public int MaxSanity = 5;
    public int MaxcharacterSanity { get { return MaxSanity; } set { MaxSanity = value; } }
    public int Stamina = 5;
    public int characterStamina { get { return Stamina; } set { Stamina = value; } }
    public int MaxStamina = 5;
    public int MaxcharacterStamina { get { return MaxStamina; } set { MaxStamina = value; } }

    public int Speed=1;
    public int characterSpeed { get { return Speed; } set { Speed = value; } }
    public int Sneak=4;
    public int characterSneak { get { return Sneak ; } set { Sneak = value; } }

    public int Fight=1;
    public int characterFight { get { return Fight; } set {  Fight= value; } }
    public int Will=4;
    public int characterWILL { get { return Will; } set { Will = value; } }

    public int Lore=1;
    public int characterLore { get { return Lore; } set {  Lore = value; } }
    public int Luck=4;
    public int characterLuck { get { return Luck; } set { Luck = value; } }

    public int Focus=3;
    public int characterFocus { get { return Focus; } set {  Focus = value; } }

    public int MinDiceSucc = 5;


    //소지품

    public int characterMoney = 0;
    public int clue = 0;


    public int maxMoveCount;  //이동가능 횟수
    public int currentMoveCount = 0;    //현재 이동횟수

    public Vector3 goalPosition;   //이동해야될 위치
    public bool movingCheck = false;   //이동중인지 체크
    public int movingDirection = 0;

    public int currentLocal_Id;


    //싱글턴 선언
    public static Character instance = null;


    private void Awake()
    {
       if(instance  == null)
        {
            instance = this;
        }
       else if(instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }


    public void StartMove(Vector3 goalPos)
    {
        goalPosition = goalPos;

        if (movingCheck == false && currentMoveCount < maxMoveCount && transform.position != goalPosition)
        {
            movingCheck = true; 
            currentMoveCount++;

            StartCoroutine(MoveController.instance.MovePosition(goalPosition));
        }   
    }

    public void MoveComplete()
    {
        movingCheck = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LOCAL")) 
            currentLocal_Id = other.GetComponent<Local>().local_Id;
        // 이동 시 몬스터 지역으로 이동, 바로 전투의 경우만 해당 
        else if (other.CompareTag("MONSTER"))
        {
            CombatController.instance.SetCombatController(this, other.GetComponent<Monster>());
        }
            
    }

    public void DamagedSanity(int damage)
    {
        Sanity -= damage;

        if (Sanity < 0)
            DieCuzSanity();

        // 애니메이션 
    }

    public void DamagedStamina(int damage)
    {
        Stamina -= damage;

        if (Stamina < 0)
            DieCuzStamina();

        // 애니메이션
    }

    void DieCuzStamina()
    {
        Debug.Log("멘탈이 0이하가 되어 죽음");

    }

    void DieCuzSanity()
    {
        Debug.Log("체력이 0이하가 되어 죽음");

    }
}
