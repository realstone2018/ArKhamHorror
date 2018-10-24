using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossNameText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Text bossname = GetComponent<Text>();
        bossname.text = GameObject.FindGameObjectWithTag("Boss").name;

    }
	
	
}
