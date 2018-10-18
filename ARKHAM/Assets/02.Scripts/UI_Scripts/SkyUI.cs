using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkyUI : MonoBehaviour {

    [SerializeField]
    public List<Image> monsterImages = new List<Image>();

    int num = 0;

    public static SkyUI instance = null;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 1; i < transform.childCount; i++) {
            monsterImages.Add(transform.GetChild(i).GetComponent<Image>());
        }
    }

    public void TakeToSky(string monsterName)
    {
        if (num < 4)
        {
            monsterImages[num].sprite = Resources.Load<Sprite>("MonsterImages/" + monsterName);
            monsterImages[num].gameObject.SetActive(true);
            num++;
        }
        else
            Debug.Log("하늘에 몬스터수가 4마리를 초과");
    }

    public void TakeToGround()
    {

    }
}
