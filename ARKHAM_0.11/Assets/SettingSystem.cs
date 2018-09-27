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

        StartPointSetting.Add(GameObject.Find("Science_Building").GetComponent<Local_ScienceBuilding>());

        for (int i = 0; i < StartPointSetting.Count;i++)
        {

            Debug.Log(i);
            Debug.Log(StartPointSetting[i].local_Id);
            Debug.Log(Character.instance.currentLocal_Id);

            if (StartPointSetting[i].local_Id==Character.instance.currentLocal_Id)
            {
                GameObject.Find("character").GetComponent<Transform>().position = new Vector3(StartPointSetting[i].position.x,1, StartPointSetting[i].position.z);
                
                Debug.Log("포지션"+StartPointSetting[i].position);
            }
            Debug.Log(i);
        }

        

        GameObject.Find("CharacterSheet").GetComponent<Image>().sprite = Character.instance.SheetImage;
    }


}
