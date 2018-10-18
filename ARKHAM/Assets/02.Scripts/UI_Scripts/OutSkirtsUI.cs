using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutSkirtsUI : MonoBehaviour {

    [SerializeField]
    public List<Image> monsterImages = new List<Image>();

    public GameObject sky;
    int num = 0;

    public static OutSkirtsUI instance = null;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateSkyUI()
    {
        num = sky.transform.childCount;

        if (num == 0)
            return;

        for (int i = 0; i < num; i++)
        {
            if (i > 5)
            {
                Debug.Log("하늘에 몬스터수가 6  마리를 초과");
                break;
            }

            Monster monster = sky.transform.GetChild(i).GetComponent<Monster>();

            monsterImages[i + 1].sprite = Resources.Load<Sprite>("MonsterImages/" + monster.id);
            monsterImages[i + 1].gameObject.SetActive(true);
        }

    }
}
