using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutSkirtsUI : MonoBehaviour {


    [SerializeField]
    public List<Image> monsterImages = new List<Image>();

    public Transform outskirtsUIPanel;
    int num = 0;

    public static OutSkirtsUI instance = null;

    private void Awake()
    {
        instance = this;

        for (int i = 1; i < outskirtsUIPanel.childCount; i++)
        {
            monsterImages.Add(outskirtsUIPanel.GetChild(i).GetComponent<Image>());
        }
    }

    public void UpdateOutSkirtsUI(string name)
    {
        // 외각의 몬스터가 7마리를 넘으면 곧포수준 한단계 업
        if (num >= 7)
        {
            TerrorLevel.instance.TerrorLevelUp();
            DeActiveImages();
            return;
        }

        monsterImages[num].sprite = Resources.Load<Sprite>("MonsterImages/" + name);
        monsterImages[num].gameObject.SetActive(true);
        num++;
    }

    public void DeActiveImages()
    {
        for (int i = 0; i < monsterImages.Count; i++)
        {
            monsterImages[i].gameObject.SetActive(false);
            num = 0;
        }
    }
}
