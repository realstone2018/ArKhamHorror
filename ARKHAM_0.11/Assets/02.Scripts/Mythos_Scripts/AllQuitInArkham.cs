using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AllQuitInArkham : Mythos {

    public AllQuitInArkham(string _title, string _explain, string _gateLocal, string _clueLocal, MythosType _mythosType, List<Monster.Simbol> _whiteSimbol, List<Monster.Simbol> _blackSimbol)
        : base(_title, _explain, _gateLocal, _clueLocal, _mythosType, _whiteSimbol, _blackSimbol)
    {
    }
   
    public override void OccurEvent()
    {
        DiceController.instance.SetDice(this, Character.instance.Luck - 1, Character.instance.MinDiceSucc, 6);
    }

    public override void EventResult(int successCount)
    {
        if (successCount > 0)
        {
            Debug.Log(this + " 신화 이벤트 성공");
        }
        else
        {
            Debug.Log(this + " 신화 이벤트 실패");
        }
    }


}
