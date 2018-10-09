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

            if (StartPointSetting[i].local_Id==Character.instance.currentLocal_Id)
            {
                GameObject.Find("character").GetComponent<Transform>().position = new Vector3(StartPointSetting[i].position.x,1, StartPointSetting[i].position.z);
                
            }
        }

        

        GameObject.Find("CharacterSheet").GetComponent<Image>().sprite = Character.instance.SheetImage;

        UpkeepButtonEvent.instance.UpkeepEnCounterStep();
        Character.instance.Focus = 100;

    }

    public void EndSetting()
    {

        UpkeepButtonEvent.instance.UpkeepStepEnd();

        MythosController.instance.FirstMythos();
    }


}
