using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterTotalCombat : MonoBehaviour {

    private Text TotalCombat;
    void Start()
    {
        TotalCombat = GetComponent<Text>();
        TotalCombat.text = Character.instance.CombatCheck.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        TotalCombat.text = Character.instance.CombatCheck.ToString();
    }
}
