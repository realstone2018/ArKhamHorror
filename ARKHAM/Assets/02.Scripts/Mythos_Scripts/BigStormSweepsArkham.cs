using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigStormSweepsArkham : Mythos
{
    public BigStormSweepsArkham(string _title, string _explain, string _gateLocal, string _clueLocal, MythosType _mythosType, List<Monster.Simbol> _whiteSimbol, List<Monster.Simbol> _blackSimbol)
        : base(_title, _explain, _gateLocal, _clueLocal, _mythosType, _whiteSimbol, _blackSimbol)
    {

    }
    
    public override void OccurEvent()
    {
        Debug.Log("하늘과 교외에 있는 모든 몬스터들이 주머니로 돌아갑습니다.");
    }

    public override void EventResult(int successCount)
    {
       
    }

}
