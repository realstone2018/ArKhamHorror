using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherWorld : MonoBehaviour {

    public int OtherWorldId;
    public Vector3 postion;
    public Vector3 OpenGareLocal;

    public enum Simbol { Circle, Triangle, Square, Diamond, Hexagon, Cross, Star, Moon, BackSlash }
    public Simbol GateSimbol;


    public static OtherWorld instance = null;


    private void Awake()
    {
        instance = this;
    }

    public void OpenGateLoalSave(Vector3 gatepostion)
    {
        OpenGareLocal = gatepostion;

    }
}
