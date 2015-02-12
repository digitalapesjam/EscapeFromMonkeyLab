using UnityEngine;
using System.Collections;

public class DocSound : MonoBehaviour {

	float timeQM;
	//bool enabled;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		GameObject qm = GameObject.Find("QM");
		if (qm == null) return;

		MeshRenderer mr = qm.GetComponent<MeshRenderer>();
		if (mr == null) return;

		Debug.Log(AudioInput.Volume);
		Debug.Log(mr.enabled);
		if (AudioInput.Volume > 3.0 && !mr.enabled)
		{
			mr.enabled = true;
			timeQM = Time.time;	
		}
		else if (mr.enabled && Time.time - timeQM > 1.5)
		{
			Debug.Log("disable");
			mr.enabled = false;
		}	
	}
}
