using UnityEngine;
using System.Collections;

public class PlaySoundOnFirstCollisionWith : MonoBehaviour {

	private bool played = false;
	public GameObject with;
	
	void Start () {
	}
	
	void OnCollisionEnter(Collision collInfo) {
		if(played) return;
		if(collInfo.collider == null) return;
		if(collInfo.collider.gameObject != with) return;
		GetComponent<AudioSource>().Play();
		played=true;
	}
	
}
