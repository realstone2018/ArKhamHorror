using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationGate : MonoBehaviour {

    void FixedUpdate () {
        transform.Rotate(Vector3.back * Time.deltaTime * 22.0f);
	}
}
