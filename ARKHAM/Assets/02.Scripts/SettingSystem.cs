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
        Vector3 startPosition;

        Local startloal = Local.GetLocalObjById(Character.instance.currentLocal_Id);
        startPosition = new Vector3(startloal.transform.position.x, 1, startloal.transform.position.z-3);    
        GameObject.Find("character").GetComponent<Transform>().position = startPosition;

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
