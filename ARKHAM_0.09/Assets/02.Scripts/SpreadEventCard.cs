using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadEventCard : MonoBehaviour {

	public void OnButtonDown()
    {
        LocalEventController.instance.SelectCard(transform.position);

        gameObject.SetActive(false);
    }
}
