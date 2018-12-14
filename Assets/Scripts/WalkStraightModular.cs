using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;
using System.Diagnostics;
using Debug=UnityEngine.Debug;

public class WalkStraightModular : MonoBehaviour {
	public float speed;
	public float movedir = 0;
	public bool isAlive = true;
	public float leftIn,rightIn;
	public float[] weights= new float[56];
	public float output;
	public float[] magnitude = new float[6];
	public float[] direction = new float[6];
	public float fitness;
	public Stopwatch zeit = new Stopwatch();
	public float timer = 0.0f;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < weights.Length; i++){
			weights[i] = 0f;
		}
		for(int i = 0; i < magnitude.Length; i++){
			magnitude[i] = 100f;
		}
			direction[0] = 0f;
			direction[1] = 30f;
			direction[2] = 60f;
			direction[3] = 120f;
			direction[4] = 150f;
			direction[5] = 180f;
		
	}

	// Update is called once per frame
	void Update () {
		//if(Input.GetMouseButtonDown(0)){
		zeit.Start();
	//	}
			if(isAlive == true){
				timer += Time.deltaTime;
				zeit.Start();
				fitness = timer;
				output = Out(Hidden1(Eye1(), Eye2(), Eye3(), Eye4(), Eye5(), Eye6()) , Hidden2(Eye1(), Eye2(), Eye3(), Eye4(), Eye5(), Eye6()) , Hidden3(Eye1(), Eye2(), Eye3(), Eye4(), Eye5(), Eye6()) , Hidden4(Eye1(), Eye2(), Eye3(), Eye4(), Eye5(), Eye6()) , Hidden5(Eye1(), Eye2(), Eye3(), Eye4(), Eye5(), Eye6()) , Hidden6(Eye1(), Eye2(), Eye3(), Eye4(), Eye5(), Eye6()) , Hidden7(Eye1(), Eye2(), Eye3(), Eye4(), Eye5(), Eye6()) , Hidden8(Eye1(), Eye2(), Eye3(), Eye4(), Eye5(), Eye6()));
				//GetFitness();
				transform.Translate(speed,0,0);
				movedir += output*5;
				Quaternion dir = Quaternion.AngleAxis(movedir, Vector3.up);
				transform.rotation = dir;
			}
			else {

			}
	}

	float Hidden1(float a, float b, float c, float d, float e, float f){
	  float outp = (a/10 * weights[0]) + (b/10 * weights[1]) + (c/10 * weights[2]) + (d/10 * weights[3]) + (e/10 * weights[4]) + (f/10 * weights[5]);
		return (float)System.Math.Tanh ((double)outp);
	}

	float Hidden2(float a, float b, float c, float d, float e, float f){
	  float outp = (a/10 * weights[6]) + (b/10 * weights[7]) + (c/10 * weights[8]) + (d/10 * weights[9]) + (e/10 * weights[10]) + (f/10 * weights[11]);
		return (float)System.Math.Tanh ((double)outp);
	}

	float Hidden3(float a, float b, float c, float d, float e, float f){
	  float outp = (a/10 * weights[12]) + (b/10 * weights[13]) + (c/10 * weights[14]) + (d/10 * weights[15]) + (e/10 * weights[16]) + (f/10 * weights[17]);
		return (float)System.Math.Tanh ((double)outp);
	}

	float Hidden4(float a, float b, float c, float d, float e, float f){
	  float outp = (a/10 * weights[18]) + (b/10 * weights[19]) + (c/10 * weights[20]) + (d/10 * weights[21]) + (e/10 * weights[22]) + (f/10 * weights[23]);
		return (float)System.Math.Tanh ((double)outp);
	}

	float Hidden5(float a, float b, float c, float d, float e, float f){
	  float outp = (a/10 * weights[24]) + (b/10 * weights[25]) + (c/10 * weights[26]) + (d/10 * weights[27]) + (e/10 * weights[28]) + (f/10 * weights[29]);
		return (float)System.Math.Tanh ((double)outp);
	}

	float Hidden6(float a, float b, float c, float d, float e, float f){
	  float outp = (a/10 * weights[30]) + (b/10 * weights[31]) + (c/10 * weights[32]) + (d/10 * weights[33]) + (e/10 * weights[34]) + (f/10 * weights[35]);
		return (float)System.Math.Tanh ((double)outp);
	}

	float Hidden7(float a, float b, float c, float d, float e, float f){
	  float outp = (a/10 * weights[36]) + (b/10 * weights[37]) + (c/10 * weights[38]) + (d/10 * weights[39]) + (e/10 * weights[40]) + (f/10 * weights[41]);
		return (float)System.Math.Tanh ((double)outp);
	}

	float Hidden8(float a, float b, float c, float d, float e, float f){
	  float outp = (a/10 * weights[42]) + (b/10 * weights[43]) + (c/10 * weights[44]) + (d/10 * weights[45]) + (e/10 * weights[46]) + (f/10 * weights[47]);
		return (float)System.Math.Tanh ((double)outp);
	}

	float Out(float a, float b, float c, float d, float e, float f, float g, float h){
	  float outp = (a/10 * weights[48]) + (b/10 * weights[49]) + (c/10 * weights[50]) + (d/10 * weights[51]) + (e/10 * weights[52]) + (f/10 * weights[53]) + (g/10 * weights[54]) + (h/10 * weights[55]);
		return (float)System.Math.Tanh ((double)outp);
	}

	float Eye1 () {
		RaycastHit intersect;
		Quaternion q = Quaternion.AngleAxis(direction[0], Vector3.up);
		Vector3 offset = new Vector3(0,0,0);
		if(Physics.Raycast(transform.position+offset,q * transform.forward, out intersect,magnitude[0])){
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

	float Eye2(){

	RaycastHit intersect;
	Quaternion q = Quaternion.AngleAxis(direction[1], Vector3.up);
	Vector3 offset = new Vector3(0,0,0);
	if(Physics.Raycast(transform.position+offset,q * transform.forward, out intersect,magnitude[1])){
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

float Eye3 () {
	RaycastHit intersect;
	Quaternion q = Quaternion.AngleAxis(direction[2], Vector3.up);
	Vector3 offset = new Vector3(0,0,0);
	if(Physics.Raycast(transform.position+offset,q * transform.forward, out intersect,magnitude[2])){
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

float Eye4 (){

RaycastHit intersect;
Quaternion q = Quaternion.AngleAxis(direction[3], Vector3.up);
Vector3 offset = new Vector3(0,0,0);
if(Physics.Raycast(transform.position+offset,q * transform.forward, out intersect,magnitude[3])){
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

float Eye5 () {
	RaycastHit intersect;
	Quaternion q = Quaternion.AngleAxis(direction[4], Vector3.up);
	Vector3 offset = new Vector3(0,0,0);
	if(Physics.Raycast(transform.position+offset,q * transform.forward, out intersect,magnitude[4])){
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

float Eye6 (){

RaycastHit intersect;
Quaternion q = Quaternion.AngleAxis(direction[5], Vector3.up);
Vector3 offset = new Vector3(0,0,0);
if(Physics.Raycast(transform.position+offset,q * transform.forward, out intersect,magnitude[5])){
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

//	public float GetFitness(){
	//fitness = (RightEye() + LeftEye())/2;
//	return fitness;
	//}

}
