using UnityEngine;
using System.Collections;

public class DocHit: MonoBehaviour {

	float timeQM;

	void Start () {
	
	}

	void Update () {
		
		GameObject qm = GameObject.Find("QM");
		if (qm == null) return;

		MeshRenderer mr = qm.GetComponent<MeshRenderer>();
		if (mr == null) return;

		//Debug.Log(AudioInput.Volume);
		//Debug.Log(mr.enabled);
		if (AudioInput.Volume > 4.0 && !mr.enabled)
		{
			mr.enabled = true;
			timeQM = Time.time;	
		}
		else if (mr.enabled && Time.time - timeQM > 1.5)
		{
			mr.enabled = false;
		}	

	}
	
	void OnCollisionEnter(Collision c){
		if (c.gameObject.name == "PlayerRef"){
			Physics.IgnoreCollision(collider,c.collider);
			GetComponents<AudioSource>()[0].Stop();
			GetComponents<AudioSource>()[1].Play();
			
			GameObject qm = GameObject.Find("QM");
			if (qm != null)
			{
				qm.GetComponent<MeshRenderer>().enabled = true;
				timeQM = Time.time;	
			}
		}
	}
}
