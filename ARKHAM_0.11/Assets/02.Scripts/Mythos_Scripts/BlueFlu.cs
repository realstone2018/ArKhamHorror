using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueFlu : Mythos
{
    public BlueFlu(string _title, string _explain, string _gateLocal, string _clueLocal, MythosType _mythosType, List<Monster.Simbol> _whiteSimbol, List<Monster.Simbol> _blackSimbol)
        : base(_title, _explain, _gateLocal, _clueLocal, _mythosType, _whiteSimbol, _blackSimbol)
    {

    }

    public override void OccurEvent()
    {
        Debug.Log("감옥에 수감된 모든 플레이어들이 풀려났습니다. ");
    }

    public override void EventResult(int successCount)
    {

    }

}
