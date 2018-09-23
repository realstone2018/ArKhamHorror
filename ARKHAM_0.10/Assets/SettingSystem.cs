using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingSystem : MonoBehaviour {

	public static SettingSystem instance = null;


    private void Awake()
    {
        instance = this;
    }

    public void SheetSetting()
    {
        GameObject.Find("CharacterSheet").GetComponent<Image>().sprite = Character.instance.SheetImage;
    }


}
