using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {
	public GameObject gameManager;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider coll){
		gameManager.GetComponent<PopulationModular>().mutationRate = 0f;
		Debug.Log(coll.gameObject.name+" HAS COMPLETED THE CHALLENGE");
	}
}
