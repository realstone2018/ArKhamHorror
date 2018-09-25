using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCard : MonoBehaviour {

    // 애니메이션 이벤트에서 호출
	public void FlipEvent()
    {
        this.transform.GetChild(3).gameObject.SetActive(false);
    }
}
