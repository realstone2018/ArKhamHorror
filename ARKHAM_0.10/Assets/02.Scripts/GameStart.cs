using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {

    public GameObject Startmenu;
    public GameObject SelectBoss;
    public GameObject SelectCharacter;

    public void SelectbossBtn()
    {
        Startmenu.SetActive(false);
        SelectBoss.SetActive(true);
    }

    public void SelectCharacterBtn()
    {
        SelectBoss.SetActive(false);
        SelectCharacter.SetActive(true);

    }

	
    public void OnClickStartBtn()
    {
        //캐릭터 초기 설정
        SceneManager.LoadScene("MainScene",LoadSceneMode.Single);
    }
}
