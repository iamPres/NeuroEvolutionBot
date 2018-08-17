using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour {
		static WalkStraight script;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider other) {
		script = other.GetComponent<WalkStraight>();
		script.isAlive = false;
		//Debug.Log("A PLAYER HAS DIED");
	}
}
