using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetView : MonoBehaviour {

	public PopulationModular script;
	public float[] rayDirection;
	public float[] rayMagnitude;
	Quaternion[] q;
	Color[] color;
	Vector3[] offset;
	float offsetRate = 2.5f;
	//private GameObject GameManager;

	// Use this for initialization
	void Start () {
		
		rayDirection = new float[script.fittestWeights.Length];
		rayMagnitude = new float[script.fittestWeights.Length];
		offset = new Vector3[script.fittestWeights.Length];

		for (int i = 0; i < script.fittestWeights.Length; i++) {
			rayMagnitude [i] = 20; 
			if (i < 6) {
				offset [i] = new Vector3 (0, 0, 0);
			}
			if (i >= 6 && i < 12) {
				offset [i] = new Vector3 (offsetRate, 0, 0);
			}
			if (i >= 12 && i < 18) {
				offset [i] = new Vector3 (offsetRate*2, 0, 0);
			}
			if (i >= 18 && i < 24) {
				offset [i] = new Vector3 (offsetRate*3, 0, 0);
			}
			if (i >= 24 && i < 30) {
				offset [i] = new Vector3 (offsetRate*4, 0, 0);
			}
			if (i >= 30 && i < 36) {
				offset [i] = new Vector3 (offsetRate*5, 0, 0);
			}
			if (i >= 36 && i < 42) {
				offset [i] = new Vector3 (offsetRate*6, 0, 0);
			}
			if (i >= 42 && i < 48) {
				offset [i] = new Vector3 (offsetRate*7, 0, 0);
			}
			if (i >= 48 && i < 56) {
				offset [i] = new Vector3 ((i-48)*offsetRate, 0, 0);
			}
		}


		for (int i = 0; i < 6; i++) {
			rayDirection [i] = 360+(i*10);
		}

		for (int i = 6; i < 48; i++) {
				rayDirection [i] = rayDirection [i - 6] - 7;
		}

		for (int i = 48; i < 56; i++) {
			rayDirection [i] = 155+(i-48)*7;
		}
		assignNet ();
			
	}
	
	// Update is called once per frame
	void Update () {
		q = new Quaternion[script.fittestWeights.Length];
		for (int i = 0; i < script.fittestWeights.Length; i++) {
			q [i] = Quaternion.AngleAxis (rayDirection [i], Vector3.up);
			Debug.DrawRay (transform.position + offset [i], q [i] * transform.forward * rayMagnitude [i], color [i]);
		}

	}

	public void assignNet() {

		color = new Color[script.fittestWeights.Length];
		for (int i = 0; i < script.fittestWeights.Length; i++) {
			if (script.fittestWeights [i] >= 0) {
				color [i] = Color.green;
				Debug.Log (color [i]);
			} else {
				color [i] = Color.red;
				Debug.Log (color [i]);
			}
		}
	
	}
}