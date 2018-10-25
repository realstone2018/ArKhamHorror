using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NowMp : MonoBehaviour {

    private Text MP;
    private void Start()
    {
        MP = GetComponent<Text>();
        MP.text = Character.instance.characterSanity.ToString();
    }
    void Update()
    {
        MP.text = Character.instance.characterSanity.ToString();

    }
}
