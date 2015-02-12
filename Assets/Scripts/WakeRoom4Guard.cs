using UnityEngine;
using System.Collections;

public class WakeRoom4Guard : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider c){
		if (c.name == "Room4GuardTrap"){
		GameObject.Find("Room4_Guard").GetComponent<TriggeredGuard>().ComeHere(transform.position);
		}
	}
}
