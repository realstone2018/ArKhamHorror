using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {

    public GameObject Startmenu;
    public GameObject SelectBossPanel;
    public GameObject SelectCharacterPanel;
    public GameObject PanelImage;
    public GameObject SelectPanel;
    private int ImageNum = 0;

    public List<Sprite> ObjectImage;


    private void Start()
    {
        ObjectImage = new List<Sprite>();
        
    }

    //게임시작버튼
    public void SelectStartBtn()
    {
        Startmenu.SetActive(false);
        SelectPanel.SetActive(true);

        ObjectImage.Add(Resources.Load<Sprite>("StartScenes/Boss/Azathoth"));
        ObjectImage.Add(Resources.Load<Sprite>("StartScenes/Boss/Yig"));
        ObjectImage.Add(Resources.Load<Sprite>("StartScenes/Boss/Cthulhu"));
    }


    //보스 선택버튼
    public void SelectBossBtn()
    {
        ObjectImage.Clear();
        SelectBossPanel.SetActive(false);
        SelectCharacterPanel.SetActive(true);

        ObjectImage.Add(Resources.Load<Sprite>("StartScenes/Character/AmandaSharpe"));
        ObjectImage.Add(Resources.Load<Sprite>("StartScenes/Character/AshcanPete"));
        ObjectImage.Add(Resources.Load<Sprite>("StartScenes/Character/BobJenkins"));
        ImageNum = 0;
        GameObject.Find("SelectImage").GetComponent<Image>().sprite = ObjectImage[ImageNum];

    }


	// 캐릭터 선택버튼
    public void SelectCharacterBtn()
    {
        Debug.Log(ImageNum);
        SelectCharacter.instance.PickCharacter(ImageNum);
        SceneManager.LoadScene("MainScene",LoadSceneMode.Single);
    }


    //이미지 변경 버튼 
    public void ImageRightBtn()
    {
        
        ImageNum += 1;
        if (ImageNum > 2)
            ImageNum = 0;
        PanelImage.GetComponent<Image>().sprite = ObjectImage[ImageNum];

    }


    public void ImageLeftBtn()
    {
        
        ImageNum -= 1;
        if (ImageNum < 0)
            ImageNum = 2;
        PanelImage.GetComponent<Image>().sprite = ObjectImage[ImageNum];

    }



}
