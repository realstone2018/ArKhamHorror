using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mythos : MonoBehaviour {

    // 설명 텍스트
    public string title;
    public string explain; 

    public Local gateLocal;
    public Local clueLocal;

    public enum MythosType { HeadLine, Environment, Rumor };
    public MythosType mythosType;
    
    public List<Monster.Simbol> whiteSimbol = new List<Monster.Simbol>();
    public List<Monster.Simbol> blackSimbol = new List<Monster.Simbol>();

    public Mythos(string _title, string _explain, string _gateLocal, string _clueLocal, MythosType _mythosType, List<Monster.Simbol> _whiteSimbol, List<Monster.Simbol> _blackSimbol)
    {
        title = _title;
        explain = _explain;
        mythosType = _mythosType;

        Type type = Type.GetType(_gateLocal);
        gateLocal = FindObjectOfType(type) as Local;

        type = Type.GetType(_clueLocal);
        clueLocal = FindObjectOfType(type) as Local;

        for (int i = 0; i < _whiteSimbol.Count; i++)
        {
            whiteSimbol.Add(_whiteSimbol[i]);
        }

        for (int i = 0; i < _blackSimbol.Count; i++)
        {
            blackSimbol.Add(_blackSimbol[i]);
        }
    }

    public void CopyValue(ref Mythos _mythos)
    {
        title = _mythos.title;
        explain = _mythos.explain;
        mythosType = _mythos.mythosType;

        gateLocal = _mythos.gateLocal;
        clueLocal = _mythos.clueLocal;

        for (int i = 0; i < _mythos.whiteSimbol.Count; i++)
        {
            whiteSimbol.Add(_mythos.whiteSimbol[i]);
        }

        for (int i = 0; i < _mythos.blackSimbol.Count; i++)
        {
            blackSimbol.Add(_mythos.blackSimbol[i]);
        }
    }


    public virtual void OccurEvent()
    {

    }

    public virtual void EventResult(int successCout)
    {

    }
}
