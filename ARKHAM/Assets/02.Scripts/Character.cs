  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    IEnumerator MovingCharacter;
    public Sprite SheetImage;


    //캐릭터스텟
    public int Sanity;
    public int characterSanity { get { return Sanity; } set { Sanity = value; } }
    public int MaxSanity;
    public int MaxcharacterSanity { get { return MaxSanity; } set { MaxSanity = value; } }
    public int Stamina;
    public int characterStamina { get { return Stamina; } set { Stamina = value; } }
    public int MaxStamina;
    public int MaxcharacterStamina { get { return MaxStamina; } set { MaxStamina = value; } }

    public int Speed;
    public int characterSpeed { get { return Speed; } set { Speed = value; } }
    public int Sneak;
    public int characterSneak { get { return Sneak ; } set { Sneak = value; } }

    public int Fight;
    public int characterFight { get { return Fight; } set {  Fight= value; } }
    public int Will;
    public int characterWILL { get { return Will; } set { Will = value; } }

    public int Lore;
    public int characterLore { get { return Lore; } set {  Lore = value; } }
    public int Luck;
    public int characterLuck { get { return Luck; } set { Luck = value; } }

    public int MaxFocus;
    public int Focus;
    public int characterFocus { get { return Focus; } set {  Focus = value; } }

    public int MinDiceSucc = 5;


    //소지품

    public int money = 0;
    public int clue = 0;


    public List<ItemCard> CharacterInventory;
    public int GateNum;
    public int SumMonsterHP;

    public int InitCommonItemNum;
    public int InitUniqutemNum;
    public int InitSpellNum;
    public int InitSkillNum;



    //전투
    public int PhysicalCombat;  //무기공격력(한손x2 or 양손)
    public int MagicalCombat;   //마법공격력
    public int EvadeCheck;  //회피 (은둔 + 기술 or 조력자 의 회피+1 의 경우, 은둔체크는 기본스텟으로,회피체크는 이 변수로)
    public int HorrorCheck; //공포
    public int CombatCheck; //투지+무기 수치
    

    //이동 관련
    public int maxMoveCount;  //이동가능 횟수
    public int currentMoveCount = 0;    //현재 이동횟수

    public Vector3 goalPosition;   //이동해야될 위치
    public int movingDirection = 0;

    public int currentLocal_Id;
    
    // 캐릭터 상태 변수,  현재는 전투 중 죽을 경우에만 사용, 모든 경우에 적용시키기 
    public enum State {IDLE, MOVE, COMBAT, FAINT};
    public State characterState = State.IDLE;

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

        if (characterState == State.IDLE && currentMoveCount < maxMoveCount && transform.position != goalPosition)
        {
            characterState = State.MOVE; 
            currentMoveCount++;
            MovingCharacter = MoveController.instance.MovePosition(goalPosition);
            StartCoroutine(MovingCharacter);
        }   
    }
   
    public void MovingComplete()
    {
        if (characterState == State.MOVE)
            characterState = State.IDLE;
    }

    public void CobatComplete()
    {
        characterState = State.IDLE;
    }

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("LOCAL"))
        {
            currentLocal_Id = other.GetComponent<Local>().local_Id;
        }
        // 이동 시 몬스터 지역으로 이동, 바로 전투의 경우만 해당 
        else if (other.CompareTag("MONSTER") && GameManager.instance.CheckState(GameManager.GameState.Move))
        {
            characterState = State.COMBAT;
            CombatController.instance.SetCombatController(this, other.GetComponent<Monster>());
        }
            

        if(other.CompareTag("Gate"))
        {
            StopCoroutine(MovingCharacter);
            MovingComplete();
            Transform OtherWorld = other.GetComponent<Gate>().OpenLocal.transform;

            transform.position = OtherWorld.position; //다른세계로 날려보내기
<<<<<<< HEAD
            
=======
            OnTriggerEnter(other);
>>>>>>> 931394b2f28e82047f7c6655b97f8b7447656188
   

        }

    }

    public void DamagedSanity(int damage)
    {
        Sanity -= damage;

        if (Sanity <= 0)
            DieCuzSanity();

        // 애니메이션 
    }

    public void DamagedStamina(int damage)
    {
        Stamina -= damage;

        if (Stamina <= 0)
            DieCuzStamina();

        // 애니메이션

    }

    void DieCuzStamina()
    {
        Debug.Log("멘탈이 0이하가 되어 죽음");

        Stamina = 1;

        Local localAsylum = GameObject.FindObjectOfType<Local_Asylum>();

        CharacterDie(localAsylum);
    }

    void DieCuzSanity()
    {
        Debug.Log("체력이 0이하가 되어 죽음");

        Sanity = 1;

        Local localHospitol = GameObject.FindObjectOfType<Local_STMarysHos>();

        CharacterDie(localHospitol);
    }

    void CharacterDie(Local local)
    {
        characterState = State.FAINT;

        Vector3 localPosition = local.transform.position;
        Vector3 pos = new Vector3(localPosition.x, 1.0f, localPosition.z - 3.0f);
        transform.position = pos;
        MaincameraController.instance.SetPosition(transform.position);

        CombatController.instance.enabled = false;

        // 잃어버릴때 애니메이션 적용 
        money = 0;
        clue = 0;
        // 아이템은 선택해서 버리게 
    }

    
}
