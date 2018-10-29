using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatUI : MonoBehaviour {

    public GameObject combatPanel;
    public GameObject combatAnimPanel;

    public GameObject bottomMenuPanel;
    public GameObject mainButtonPanel;

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

        combatPanel.SetActive(true);
    }


    public void StartCombat()
    {

    }


    public void CombatUIActive(bool value)
    {
        combatPanel.SetActive(value);
    }

    public void CombatAnimUIActive(bool value)
    {
        combatAnimPanel.SetActive(value);
    }

    public void PlayerWinAnim()
    {
        combatAnimPanel.GetComponent<Animator>().SetBool("PlayerWin", true);
    }

    public void PlayerLoseAnim()
    {
        combatAnimPanel.GetComponent<Animator>().SetBool("MonsterWin", true);
    }

    public void FinishCombatAnim()
    {
        combatAnimPanel.GetComponent<Animator>().SetBool("FinishCombat", true);
    }
}
