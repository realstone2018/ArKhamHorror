using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMagicalCombat : MonoBehaviour {

    private Text MagicalCombat;
    void Start()
    {
        MagicalCombat = GetComponent<Text>();
        MagicalCombat.text = Character.instance.characterMagicalCombat.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        MagicalCombat.text = Character.instance.MagicalCombat.ToString();
    }
}
