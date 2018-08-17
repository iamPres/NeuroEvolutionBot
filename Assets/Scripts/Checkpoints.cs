using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour {
public Vector3 center = new Vector3(0,0,0);
public int checkPointAmount = 360;
public Ray[] ray;
int layerMask;
	// Use this for initialization
	void Start () {
		layerMask = LayerMask.GetMask("Players");
		ray = new Ray[checkPointAmount];
	}

	// Update is called once per frame
	void Update () {
		RaycastHit[] hit = new RaycastHit[checkPointAmount];
		Quaternion[] q = new Quaternion[checkPointAmount];

			for(int i=0;i<checkPointAmount;i++){
				q[i] = Quaternion.AngleAxis(i, Vector3.up);
				ray[i] = new Ray(center,q[i]*transform.forward);
				if (Physics.Raycast(ray[i], out hit[i],100,layerMask)) {
						//hit[i].transform.gameObject.GetComponent<WalkStraight>().fitness = i;
							Debug.Log(i+" DEGREES = "+" "+hit[i].distance);
				}
					Debug.DrawRay(center,q[0]*transform.forward*100,Color.red);

		}
	}
}
