using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

	public enum Type {Normal, Fly, Fast, Fixed, SMovement}

    public enum Simbol { Circle, Triangle, Square, Diamond, Hexagon, Cross, Star, Moon, BackSlash }
    
    // 매복, 물리저항, 마법저항, 물리먼역, 마법먼역, 악몽, 압도, 언데드
    public enum SAttribute{None, Ambush, PhysicalResist, MagicalResist, PhysicalImmunity, MagicalImmunity, Nightmarsh, OverWhelming, Undead}

    // 이름, 체력, 공포수준, 전투수준, 체력피해, 정신력피해, 회피수준, 타입, 문양, 특수속성
    public string id;
    public int hp;
    public int fearLevel;
    public int combatLevel;
    public int staminaDamage;
    public int sanityDamage;
    public int evasionLevel;
    public Type type;
    public Simbol simbol;
    public List<SAttribute> sAttribute = new List<SAttribute>();

    public Monster(string _name, int _hp, int _fearLevel, int _combatLevel, int _staminaDamage, int _sanityDamage, int _evasionLevel, Type _type, Simbol _simbol, List <SAttribute> _sAttribute)
    {
        id = _name;
        hp = _hp;
        fearLevel = _fearLevel;
        combatLevel = _combatLevel;
        staminaDamage = _staminaDamage;
        sanityDamage = _sanityDamage;
        evasionLevel = _evasionLevel;
        type = _type;
        simbol = _simbol;

        // 리시트를 매개변수로 받거나 리스트간의 대입시 call by referance이므로 하나씩 Ad
        for (int i = 0; i < _sAttribute.Count; i++)
        {
            sAttribute.Add(_sAttribute[i]);
        }
    }

    // 대입 연산자 오버로딩할랬는데 C#은 대입연산자는 오버로딩 불가능
    // ref는 참조자(&)를 의미 

    public void CallValue(ref Monster mon)
    {
        name = mon.id;

        id = mon.id;
        hp = mon.hp;
        fearLevel = mon.fearLevel;
        combatLevel = mon.combatLevel;
        staminaDamage = mon.staminaDamage;
        sanityDamage = mon.sanityDamage;
        evasionLevel = mon.evasionLevel;
        type = mon.type;
        simbol = mon.simbol;

        for (int i = 0; i < mon.sAttribute.Count; i++)
        {
            sAttribute.Add(mon.sAttribute[i]);
        }
    }
}
