using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalEventDictionary : MonoBehaviour
{
    //public Character character;
    public Character character;

    string functionName;

    public Local[] locals;

    public static LocalEventDictionary instance;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        locals = GameObject.FindObjectsOfType<Local>();
    }

    public void DrawEvent()
    {
        int local_Id = character.currentLocal_Id;
        int ran = Random.Range(1, 7);

        
        foreach (Local local in locals)
        {
            if (local.local_Id == local_Id)
                functionName = local+ "_" + ran.ToString();
        }

        Invoke(functionName, 0.0f);
    }

    public void Info_1()
    {
        Debug.Log("Event_01");
    }

    public void Info_2()
    {
        Debug.Log("Event_02");
    }

    public void Info_3()
    {
        Debug.Log("Event_03");
    }

}