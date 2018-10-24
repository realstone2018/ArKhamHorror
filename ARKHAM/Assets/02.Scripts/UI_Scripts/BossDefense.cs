using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossDefense : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Text bossDefense = GetComponent<Text>();
        bossDefense.text = Boss.instance.BossDefense.ToString();

    }


}
