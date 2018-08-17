using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkStraight : MonoBehaviour {
	public float speed;
	public float movedir = 0;
	public bool isAlive = true;
	public float leftIn,rightIn;
	public float[] weights= new float[10];
	public float output;
	public float magnitudeL;
	public float magnitude;
	public float direction;
	public float directionL;
	public float fitness;

	// Use this for initialization
	void Start () {
		weights[0] = 0f;///Random.Range(-1f,1f);
		weights[1] = 0f;//Random.Range(-1f,1f);
	}

	// Update is called once per frame
	void Update () {
		//if(Input.GetMouseButtonDown(0)){

	//	}
			if(isAlive == true){
				fitness++;
				output = Node(LeftEye(), RightEye());
				//GetFitness();
				transform.Translate(speed,0,0);
				movedir += output*5;
				Quaternion dir = Quaternion.AngleAxis(movedir, Vector3.up);
				transform.rotation = dir;
			}
			else {

			}
	}

	float Node(float a, float b){
	  float outp = (a/10 * weights[0]) + (b/10 * weights[1]);
		return (float)System.Math.Tanh ((double)outp);
	}

	float RightEye () {
		RaycastHit intersect;
		Quaternion q = Quaternion.AngleAxis(direction, Vector3.up);
		Vector3 offset = new Vector3(0,0,0);
		if(Physics.Raycast(transform.position+offset,q * transform.forward, out intersect,magnitude)){
			//Debug.Log("RIGHT RAY WAS HIT");
			Debug.DrawRay(transform.position+offset,q * transform.forward * intersect.distance,Color.red);
			//script.movedir--;
			//Debug.Log("Right eye sees something "+intersect.distance+" meters away!");
			return intersect.distance;

		}
		else {
			//Debug.DrawRay(transform.position+offset,q * transform.forward * magnitude,Color.green);
			return 0;
		}

	}

	float LeftEye(){

	RaycastHit intersect;
	Quaternion q = Quaternion.AngleAxis(directionL, Vector3.up);
	Vector3 offset = new Vector3(0,0,0);
	if(Physics.Raycast(transform.position+offset,q * transform.forward, out intersect,magnitudeL)){
		//Debug.Log("LEFT RAY WAS HIT");
		Debug.DrawRay(transform.position+offset,q * transform.forward * intersect.distance,Color.red);
		//script.movedir++;
		//Debug.Log("Left eye sees something "+intersect.distance+" meters away!");
		return intersect.distance;
	}
	else {
		//Debug.DrawRay(transform.position+offset,q * transform.forward * intersect,Color.green);
		return 0;
	}
}

	public float GetFitness(){
	fitness = (RightEye() + LeftEye())/2;
	return fitness;
	}

}
