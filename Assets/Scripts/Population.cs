using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Population : MonoBehaviour {

public static int pop = 50;
public GameObject Player;
GameObject[] PlayerClone = new GameObject[pop];
public int deathCount = 0;
public int epoch;
private float[] fittestGene = new float[10];
private GameObject fittestPlayer;
public float mutationRate;
private WalkStraight[] script = new WalkStraight[pop];
public Text uiEpoch;
public Text uiFittest;
public Text uiAvg;
float avg;

	void Start() {
		epoch = 1;
		for(int i=0;i<pop;i++){
			PlayerClone[i] = Instantiate(Player,Player.transform.position,Quaternion.identity) as GameObject; //Create Population
			PlayerClone[i].name="Player"+i;
			script[i] = PlayerClone[i].GetComponent<WalkStraight>();
		}
	}

	void Update () {
		string col,col1;
		uiEpoch.text = "Generation "+epoch;

		if(deathCount >= pop){
			DetermineFittestPlayer();
			if(fittestPlayer.GetComponent<WalkStraight>().weights[0] <= 0) {
				col = "red";
			}else{
				col = "green";
			}
			if(fittestPlayer.GetComponent<WalkStraight>().weights[1] <= 0) {
				col1 = "red";
			}else{
				col1 = "green";
			}
			uiFittest.text = "<b>Fittest: </b>"+fittestPlayer.name+ " -> "+fittestPlayer.GetComponent<WalkStraight>().fitness+"m -> "+"<color="+col+">"+fittestPlayer.GetComponent<WalkStraight>().weights[0]+"</color>"+" : "+"<color="+col1+">"+fittestPlayer.GetComponent<WalkStraight>().weights[1]+"</color>";
			//if (fittestPlayer.GetComponent<WalkStraight>().weights[0] > 0 && fittestPlayer.GetComponent<WalkStraight>().weights[0] > 0) uiFittest.text = "Fittest: "+fittestPlayer.name+ " -> "+fittestPlayer.GetComponent<WalkStraight>().fitness+"m -> "+fittestPlayer.GetComponent<WalkStraight>().weights[0]+" : "+fittestPlayer.GetComponent<WalkStraight>().weights[1];
			//if (fittestPlayer.GetComponent<WalkStraight>().weights[0] > 0 && fittestPlayer.GetComponent<WalkStraight>().weights[0] < 0) uiFittest.text = "Fittest: "+fittestPlayer.name+ " -> "+fittestPlayer.GetComponent<WalkStraight>().fitness+"m -> "+fittestPlayer.GetComponent<WalkStraight>().weights[0]+" : "+fittestPlayer.GetComponent<WalkStraight>().weights[1];
			//if (fittestPlayer.GetComponent<WalkStraight>().weights[0] < 0 && fittestPlayer.GetComponent<WalkStraight>().weights[0] > 0) uiFittest.text = "Fittest: "+fittestPlayer.name+ " -> "+fittestPlayer.GetComponent<WalkStraight>().fitness+"m -> "+fittestPlayer.GetComponent<WalkStraight>().weights[0]+" : "+fittestPlayer.GetComponent<WalkStraight>().weights[1];
			uiAvg.text = "<b>Average: </b>"+avg;
			Mate();
			Mutate();
			LoadEpoch();
		}
		CountDeaths();
	}

	 void CountDeaths () {
		 deathCount = 0;
		for(int i=0;i<pop;i++){
			if (PlayerClone[i].GetComponent<WalkStraight>().isAlive == false){
				deathCount++;
			}
		}
	}

	void LoadEpoch() {
		epoch++;
		Debug.Log("<b>EPOCH: "+epoch+"</b>");
		Debug.Log("	FITTEST : "+fittestPlayer.GetComponent<WalkStraight>().fitness+" -> "+fittestPlayer.name+" -> "+fittestPlayer.GetComponent<WalkStraight>().weights[0]+" : "+fittestPlayer.GetComponent<WalkStraight>().weights[1]);
		Debug.Log("	AVERAGE: "+avg);
		for(int i=0;i<pop;i++){
			PlayerClone[i].GetComponent<WalkStraight>().isAlive = true;
			PlayerClone[i].transform.position = Player.transform.position;
			PlayerClone[i].GetComponent<WalkStraight>().movedir = 0;
			PlayerClone[i].GetComponent<WalkStraight>().fitness  = 0;
		}
	}

	GameObject DetermineFittestPlayer(){
		float fittest = 0;

		for(int i=0;i<pop;i++){
			if (PlayerClone[i].GetComponent<WalkStraight>().fitness > fittest) {
				fittest = PlayerClone[i].GetComponent<WalkStraight>().fitness;
				fittestPlayer = PlayerClone[i];
			}
		}
		return fittestPlayer;
	}

	void Mate(){
		avg = 0;
		for(int i=0;i<pop;i++){
			avg += PlayerClone[i].GetComponent<WalkStraight>().fitness;
			PlayerClone[i].GetComponent<WalkStraight>().weights[0] = fittestPlayer.GetComponent<WalkStraight>().weights[0];
			PlayerClone[i].GetComponent<WalkStraight>().weights[1] = fittestPlayer.GetComponent<WalkStraight>().weights[1];
		}
		avg /= pop;
		}
		void Mutate(){
			for(int i=0;i<pop;i+=2){
				if(PlayerClone[i].name != fittestPlayer.name) {
			PlayerClone[i].GetComponent<WalkStraight>().weights[0] += Random.Range(-mutationRate,mutationRate);
			PlayerClone[i].GetComponent<WalkStraight>().weights[1] += Random.Range(-mutationRate,mutationRate);
		}
		}
		}
	}
