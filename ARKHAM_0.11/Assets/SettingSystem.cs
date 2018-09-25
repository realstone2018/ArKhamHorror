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
        List<Local> StartPointSetting = new List<Local>();

        StartPointSetting.Add(new Local_ScienceBuilding(9900411));

        for (int i = 0; i < StartPointSetting.Count;i++)
        {

            Debug.Log(i);

            if (StartPointSetting[i].local_Id==Character.instance.currentLocal_Id)
            {
                GameObject.Find("character").GetComponent<Transform>().position = StartPointSetting[i].position;
                Debug.Log("포지션"+StartPointSetting[i].position);
            }
            Debug.Log(i);
        }

        

        GameObject.Find("CharacterSheet").GetComponent<Image>().sprite = Character.instance.SheetImage;
    }


}
