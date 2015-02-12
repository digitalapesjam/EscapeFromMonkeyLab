using UnityEngine;
using System.Collections;

public class OpenDoorByGuard : MonoBehaviour {
	public GameObject door;
	public GameObject guard;
	// Use this for initialization
	//private Animation animation;
	void Start () {
		//animation= door.GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider c){
		//Debug.Log("play animation"+door.name);
		//animation= door.GetComponent<Animation>();
		//door.animation.Play();
		//door.animation.Play();
		if (c.name == guard.name){
		//Guard.GetComponent<TriggeredGuard>().ComeHere(transform.position);
			door.animation.Play();
		}
	}
	
}
