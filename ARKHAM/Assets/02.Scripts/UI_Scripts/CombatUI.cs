using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatUI : MonoBehaviour {

    // 처음 비활성화 상태이므로 직접참조 필요 
    public GameObject bottomMenuPanel;
    public GameObject mainButtonPanel;
    public GameObject combatAnimPanel;

    public Image charStamina;
    public Image charSanity;
    public Text charStat;

    public Image monsterImage;
    public Image monStamina;
    public Text monStat;
    public Text monAbility;

    public static CombatUI instance = null;

    private void Awake()
    {
        instance = this;
    }

    public void SetCombatUI(string monName)
    {
        monsterImage.sprite = Resources.Load<Sprite>("MonsterImages/" + monName);
        mainButtonPanel.SetActive(false);
        combatAnimPanel.SetActive(false);

    }

    public void StartCombat()
    {

    }
}
