using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {

	
    public void OnClickStartBtn()
    {
        SceneManager.LoadScene("MainScene",LoadSceneMode.Single);
    }
}
