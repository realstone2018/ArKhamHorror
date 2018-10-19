using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutSkirtsUI : MonoBehaviour {


    [SerializeField]
    public List<Image> monsterImages = new List<Image>();

    public Transform outskirtsUIPanel;
    public Transform outSkirtsLocal;
    int num = 0;

    public static OutSkirtsUI instance = null;

    private void Awake()
    {
        instance = this;

        outSkirtsLocal = GameObject.FindObjectOfType<Local_OutSkirts>().transform;

        for (int i = 1; i < outskirtsUIPanel.childCount; i++)
        {
            monsterImages.Add(outskirtsUIPanel.GetChild(i).GetComponent<Image>());
        }
    }

    public void UpdateOutSkirtsUI()
    {
        num = outSkirtsLocal.childCount;

        if (num == 0)
            return;

        for (int i = 0; i < num; i++)
        {
            Monster monster = outSkirtsLocal.GetChild(i).GetComponent<Monster>();

            monsterImages[i].sprite = Resources.Load<Sprite>("MonsterImages/" + monster.id);
            monsterImages[i].gameObject.SetActive(true);
        }

    }
}
