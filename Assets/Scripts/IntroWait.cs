using UnityEngine;
using System.Collections;

public class IntroWait : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Escape))
			Application.Quit();
		if(Input.GetKeyDown(KeyCode.Space)) {
			GameObject.Find("Loading").GetComponent<GUIText>().enabled = true;
			Application.LoadLevel("Game");
		}
	}
}
