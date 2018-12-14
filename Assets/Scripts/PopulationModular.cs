using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulationModular : MonoBehaviour {

	public static int pop = 10;
	public GameObject Player;
	GameObject[] PlayerClone = new GameObject[pop];
	public int deathCount = 0;
	public int epoch;
	private GameObject fittestPlayer;
	public float mutationRate;
	private WalkStraightModular[] script = new WalkStraightModular[pop];
	public Text uiEpoch;
	public Text uiFittest;
	public Text uiAvg;
	private float fittest = 0;
	public float[] fittestWeights;
	float avg;
	public NetView netScript;
	public string[] names = new string[10] {"PussySlayer", "BadBoiBrad", "BigDickMoe", "Killahhh", "MotherFucker", "DickWhipped","xX420rulezXx","xDRxKOCKx","HentaiLover","Scrotum_"};

	void Start() {
		epoch = 1;
		for(int i=0;i<pop;i++){
			PlayerClone[i] = Instantiate(Player,Player.transform.position,Quaternion.identity) as GameObject; //Create Population
			PlayerClone[i].name=names[i]+((i*24)+11);
			script[i] = PlayerClone[i].GetComponent<WalkStraightModular>();
		}
		uiAvg.text = "<b>Average: </b>";
		uiFittest.text = "<b>Fittest: </b>";
		fittestWeights = new float[PlayerClone [0].GetComponent<WalkStraightModular> ().weights.Length];

	}

	void Update () {
		string[] col = new string[PlayerClone[0].GetComponent<WalkStraightModular>().weights.Length];
		uiEpoch.text = "Generation "+epoch;

		if(deathCount >= pop){
			DetermineFittestPlayer();
			for(int i=0;i<fittestPlayer.GetComponent<WalkStraightModular>().weights.Length;i++){
			if(fittestPlayer.GetComponent<WalkStraightModular>().weights[i] <= 0) {
				col[i] = "red";
			}else{
				col[i] = "green";
			}
			}
			uiFittest.text = "<b>Fittest: </b>" + fittestPlayer.name + "  " + fittest + "m  ";
			//if (fittestPlayer.GetComponent<WalkStraight>().weights[0] > 0 && fittestPlayer.GetComponent<WalkStraight>().weights[0] > 0) uiFittest.text = "Fittest: "+fittestPlayer.name+ " -> "+fittestPlayer.GetComponent<WalkStraight>().fitness+"m -> "+fittestPlayer.GetComponent<WalkStraight>().weights[0]+" : "+fittestPlayer.GetComponent<WalkStraight>().weights[1];
			//if (fittestPlayer.GetComponent<WalkStraight>().weights[0] > 0 && fittestPlayer.GetComponent<WalkStraight>().weights[0] < 0) uiFittest.text = "Fittest: "+fittestPlayer.name+ " -> "+fittestPlayer.GetComponent<WalkStraight>().fitness+"m -> "+fittestPlayer.GetComponent<WalkStraight>().weights[0]+" : "+fittestPlayer.GetComponent<WalkStraight>().weights[1];
			//if (fittestPlayer.GetComponent<WalkStraight>().weights[0] < 0 && fittestPlayer.GetComponent<WalkStraight>().weights[0] > 0) uiFittest.text = "Fittest: "+fittestPlayer.name+ " -> "+fittestPlayer.GetComponent<WalkStraight>().fitness+"m -> "+fittestPlayer.GetComponent<WalkStraight>().weights[0]+" : "+fittestPlayer.GetComponent<WalkStraight>().weights[1];
			uiAvg.text = "<b>Average: </b>"+avg+"m";
			Mate();
			Mutate();
			LoadEpoch();
		}
		CountDeaths();
	}

	 void CountDeaths () {
		 deathCount = 0;
		for(int i=0;i<pop;i++){
			if (PlayerClone[i].GetComponent<WalkStraightModular>().isAlive == false){
				deathCount++;
			}
		}
	}

	void LoadEpoch() {
		epoch++;
		netScript.assignNet();
		Debug.Log("<b>EPOCH: "+epoch+"</b>");
		Debug.Log("	FITTEST : "+fittest+" -> "+fittestPlayer.name+" -> "+fittestPlayer.GetComponent<WalkStraightModular>().weights[0]+" : "+fittestPlayer.GetComponent<WalkStraightModular>().weights[1]+" : "+fittestPlayer.GetComponent<WalkStraightModular>().weights[2]+" : "+fittestPlayer.GetComponent<WalkStraightModular>().weights[3]+" : "+fittestPlayer.GetComponent<WalkStraightModular>().weights[4]+" : "+fittestPlayer.GetComponent<WalkStraightModular>().weights[5]);
		Debug.Log("	AVERAGE: "+avg);
		for(int i=0;i<pop;i++){
			Debug.Log("FIT"+PlayerClone[i].GetComponent<WalkStraightModular>().fitness);
			PlayerClone[i].GetComponent<WalkStraightModular>().isAlive = true;
			PlayerClone[i].transform.position = Player.transform.position;
			PlayerClone[i].GetComponent<WalkStraightModular>().movedir = 0;
			PlayerClone[i].GetComponent<WalkStraightModular>().fitness  = 0;
			PlayerClone[i].GetComponent<WalkStraightModular>().timer  = 0.0f;
		}
	}

	GameObject DetermineFittestPlayer(){

	for(int i=0;i<pop;i++){
			if (PlayerClone[i].GetComponent<WalkStraightModular>().fitness > fittest) {
				fittest = PlayerClone[i].GetComponent<WalkStraightModular>().fitness;
				fittestPlayer = PlayerClone[i];
			}
		}
		for (int i = 0; i < PlayerClone [0].GetComponent<WalkStraightModular> ().weights.Length; i++) {
			fittestWeights [i] = fittestPlayer.GetComponent<WalkStraightModular> ().weights [i];
		}
		return fittestPlayer;
	}

	void Mate(){
		avg = 0;
		for(int i=0;i<pop;i++){
			avg += PlayerClone[i].GetComponent<WalkStraightModular>().fitness;
			for(int p=0;p<PlayerClone[i].GetComponent<WalkStraightModular>().weights.Length;p++){
				PlayerClone[i].GetComponent<WalkStraightModular>().weights[p] = fittestPlayer.GetComponent<WalkStraightModular>().weights[p];
			}
		}
		avg /= pop;
		}
		void Mutate(){
			for(int i=0;i<pop;i++){
				if(PlayerClone[i].name == fittestPlayer.name) {
				}
				else{
					for(int p=0;p<PlayerClone[i].GetComponent<WalkStraightModular>().weights.Length;p++){
						PlayerClone[i].GetComponent<WalkStraightModular>().weights[p] += Random.Range(-mutationRate,mutationRate);
						//PlayerClone[i].GetComponent<WalkStraightModular>().weights[p] = 0f;
					}
		}
		}
		}
	}
