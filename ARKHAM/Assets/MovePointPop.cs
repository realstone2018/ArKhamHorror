using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePointPop : MonoBehaviour {


    
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = (Character.instance.maxMoveCount - Character.instance.currentMoveCount).ToString();
	}
}
