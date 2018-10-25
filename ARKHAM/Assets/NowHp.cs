using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NowHp : MonoBehaviour {

    private Text HP;
    private void Start()
    {
        HP = GetComponent<Text>();
        HP.text = Character.instance.characterStamina.ToString();
    }
    void Update()
    {
        HP.text = Character.instance.characterStamina.ToString();

    }
}
