using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {

    
    public Monster.Simbol GateSimbol;
    public Local OpenLocal;

    public Monster[] BackMonster;

    public void CloseGate()
    {
        
        BackMonster = FindObjectsOfType<Monster>();
        Debug.Log("게이트 닫힐시 해당 심볼 몬스터 삭제");
        for (int i = 0;i<BackMonster.Length ;i++)
        {
            
            if(BackMonster[i].simbol == GateSimbol)
            {
                GameObject DestroyMonster = GameObject.Find(BackMonster[i].name);
                Destroy(DestroyMonster.gameObject);

                
                //몬스터 삭제
            }
        }
    }
}
