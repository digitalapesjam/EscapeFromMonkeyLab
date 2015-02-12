using UnityEngine;
using System.Collections;

public class AudioListenerFollowCamera : MonoBehaviour {

	void Start () {

	}
	
	void Update () {
		gameObject.transform.position = new Vector3(Camera.main.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z) ;
	}
}
