using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossAattackEvasion : MonoBehaviour {

    private Text BossEvasion;
   
    void Start () {
        BossEvasion = GetComponent<Text>();
        BossEvasion.text = Boss.instance.misscombate;

    }
	

}
