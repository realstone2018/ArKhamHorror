using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NowPhase : MonoBehaviour {

    private Text nowPhase;
    private void Start()
    {
        nowPhase = GetComponent<Text>();
        nowPhase.text = GameManager.instance.gameState.ToString();
    }
    void Update()
    {
            nowPhase.text = GameManager.instance.gameState.ToString();
    }
}
