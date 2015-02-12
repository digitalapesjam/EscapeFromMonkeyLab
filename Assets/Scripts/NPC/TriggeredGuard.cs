using UnityEngine;
using System.Collections;
using System.Timers;
using System;

public class TriggeredGuard : MonoBehaviour {

	public float Speed = 0.0001f;
	public float Range = 50;
	private int steps = 0;
	private Vector3 direction;
	private Vector3 destination;
	private bool huntMode = false;

	// Use this for initialization
	void Start () {
		direction = new Vector3(-1,0,0);
	}

	public void ComeHere(Vector3 destination){
			huntMode = true;
			this.destination = destination;
	}
	
	private void ProceedToTarget(){
		
		direction = destination.x < transform.position.x ? new Vector3(-1,0,0) : new Vector3(1,0,0);
		if (Math.Abs( destination.x - transform.position.x) < 10 )
		{
			huntMode = false;
			Range = 50;
		}
		else
			transform.position += direction * this.Speed*2;
	}
	
	private void Patrol(){
			
		if(this.steps >= Range){
			direction.x=direction.x*(-1);
			this.steps=0;
		}
		this.steps+=1;
		transform.position += direction*this.Speed/5f;
		
	}

	// Update is called once per frameChaserGuard : Mono
	void Update () {
		if(huntMode){
			ProceedToTarget();
		}else{
			Patrol();
		}
	}
}
