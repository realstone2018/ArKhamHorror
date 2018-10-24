using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossCombatCheck : MonoBehaviour {

    private Text bosscombatcheck;
    // Use this for initialization
    void Start () {
        bosscombatcheck= GetComponent<Text>();
        bosscombatcheck.text = Boss.instance.CombatCheck.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        if (FinalBattle.instance.phase == FinalBattle.BattlePhase.CharacterPhaseSelect)
        {
            bosscombatcheck.text = Boss.instance.CombatCheck.ToString();
        }

    }
}
