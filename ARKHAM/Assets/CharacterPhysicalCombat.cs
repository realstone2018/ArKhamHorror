using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPhysicalCombat : MonoBehaviour {

    private Text PhysicalCombat;
    void Start () {
        PhysicalCombat = GetComponent<Text>();
        PhysicalCombat.text = Character.instance.characterPhysicalCombat.ToString();
    }
	
	// Update is called once per frame
	void Update () {

        PhysicalCombat.text = Character.instance.characterPhysicalCombat.ToString();
    }
}
