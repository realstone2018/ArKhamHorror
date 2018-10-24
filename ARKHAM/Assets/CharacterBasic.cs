using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBasic : MonoBehaviour {

    private Text bossHP;

    void Start () {
        bossHP = GetComponent<Text>();
        bossHP.text = Character.instance.characterFight.ToString();
    }
	
	// Update is called once per frame
	void Update () {

        if (FinalBattle.instance.phase == FinalBattle.BattlePhase.UpKeep)
        {
            bossHP.text = Character.instance.characterFight.ToString();
        }
    }
}
