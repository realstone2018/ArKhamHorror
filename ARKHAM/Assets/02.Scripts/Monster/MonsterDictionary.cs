using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDictionary : MonoBehaviour {

    public Dictionary<string, Monster> monsterMap;

    public static MonsterDictionary instance;


    void Awake()
    {
        instance = this;
    
        monsterMap = new Dictionary<string, Monster>();

        string name;
        List<Monster.SAttribute> sAttribute = new List<Monster.SAttribute>();


        /////////////////////// None //////////////////////////////////////////
        sAttribute.Add(Monster.SAttribute.None);

        // 추종자
        name = "Cultist";
        monsterMap.Add(name, new Monster(name, 1, 0, 1, 1, 0, -3, Monster.Type.Normal, Monster.Simbol.Moon, sAttribute));

        // 차원에서 휘청대는자
        name = "DimensionalShambler";
        monsterMap.Add(name, new Monster(name, 1, -2, -2, 0, 1, -3, Monster.Type.Normal, Monster.Simbol.Square, sAttribute));

        // 미고
        name = "MiGo";
<<<<<<< HEAD
        monsterMap.Add(name, new Monster(name, 1, -1, 0, 1, 2, -2, Monster.Type.Normal, Monster.Simbol.Circle, sAttribute));

=======
        monsterMap.Add(name, new Monster(name, 1, -1, 0, 1, 2, -2, Monster.Type.Fast, Monster.Simbol.Circle, sAttribute));
       
>>>>>>> BossAndGate
        sAttribute.Clear();
        


        /////////////////////// PhysicalImmunity //////////////////////////////////////////
        sAttribute.Add(Monster.SAttribute.PhysicalImmunity);

        // 틴달로스의 개 
        name = "HoundofTindalos";
        monsterMap.Add(name, new Monster(name, 2, -2, -1, 3, 4, -1, Monster.Type.Normal, Monster.Simbol.Square, sAttribute));   
        
        sAttribute.Clear();


        /////////////////////// Various //////////////////////////////////////////
        // 유령 
        name = "Ghost";
        sAttribute.Add(Monster.SAttribute.PhysicalImmunity);
        sAttribute.Add(Monster.SAttribute.Undead);
        monsterMap.Add(name, new Monster(name, 1, -2, -3, 2, 2, -3, Monster.Type.Normal, Monster.Simbol.Moon, sAttribute));
    }


    public Monster SearchMonster(string _name)
    {
        if(monsterMap.ContainsKey(_name))
        {
            Monster monster = monsterMap[_name];

            return monster;
        }

        return null;
    }

    
    public Monster RandomMonster()
    {
        var enumerator = monsterMap.GetEnumerator();
        // GetEnumerator() 시에는 아무값도 x, MoveNext()한번 해야 처음 Add한 값이 나온다.

        int num = Random.Range(1, 6);
       
        for (int i = 0; i < num; i++) {
            enumerator.MoveNext();
        }

        var random = enumerator.Current;

        Monster randomMon = random.Value;
        return randomMon; 
    }
}
