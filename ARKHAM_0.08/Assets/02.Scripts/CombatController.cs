using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour {
    
    public static CombatController instance = null;
    private void Awake()
    {
        instance = this;
    }
    /*
    public  void Combat(TestPlayer player, TestMonster monster)
    {
        while (player.Hp <= 0 || monster.Hp <= 0)
        {
            monster.Hp -= player.Power;
            player.Hp -= monster.Power;
        }

        if (monster.Hp <= 0) {
            monster.Die();
            return;
        }
        if (player.Hp <= 0) {
            player.Die();
            return;
        }
    }
    */
}
