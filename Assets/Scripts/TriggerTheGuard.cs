using UnityEngine;
using System.Collections;

public class TriggerTheGuard: MonoBehaviour {

	public GameObject Guard;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision c){
		if (c.gameObject.name == "PlayerRef"){
			Guard.GetComponent<TriggeredGuard>().ComeHere(transform.position);
		}
	}
	
	void OnTriggerEnter(Collider c){
		if (c.name == "PlayerRef"){
			Guard.GetComponent<TriggeredGuard>().ComeHere(transform.position);
		}
	}
}
