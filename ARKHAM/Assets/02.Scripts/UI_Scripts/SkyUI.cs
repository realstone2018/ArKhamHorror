using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkyUI : MonoBehaviour {

    [SerializeField]
    public List<Image> monsterImages = new List<Image>();

    public Transform skyUIPanel;
    public Transform skyLocal;
    int num = 0;

    public static SkyUI instance = null;


    private void Awake()
    {
        instance = this;

        for (int i = 1; i < skyUIPanel.childCount; i++)
        {
            monsterImages.Add(skyUIPanel.GetChild(i).GetComponent<Image>());
        }
    }


    private void Start()
    {
        skyLocal = GameObject.FindObjectOfType<Local_Sky>().transform;
    }


    public void UpdateSkyUI()
    {
        num = skyLocal.childCount;

        if (num == 0)
            return;

        for (int i = 0; i < num; i++)
        {
            Monster monster = skyLocal.GetChild(i).GetComponent<Monster>();

            monsterImages[i].sprite = Resources.Load<Sprite>("MonsterImages/" +monster.id);
            monsterImages[i].gameObject.SetActive(true);
        }
        
    }
}
