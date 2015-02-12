using UnityEngine;
using System.Collections;

public class TriggerFinalButtonActions : MonoBehaviour {

	
	public AudioSource badSound;
	public AudioSource goodSound;
	public GameObject roboGuard;

	public Texture2D texOn;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find("PlayerRef").transform.position.y < 0){
			Camera.main.GetComponent<CameraControl>().enabled = false;
			Camera.main.GetComponent("SmoothLookAt").SendMessage("Enable");
			//GameObject.Find("Room5_Guard").GetComponent<Rigidbody>().useGravity = true;
			//GameObject.Find("Room5_Guard").GetComponent<Rigidbody>().isKinematic = false;
			Camera.main.GetComponent("GameOverGUI").SendMessage("Enable");
		}
	}
	
	void OnTriggerEnter(Collider c){
		if(c.name == "PlayerRef")
		{
			badSound.Play();
			
			GameObject btn = GameObject.Find("ExitButton");
			if (btn)
			{
				MeshRenderer mr = btn.GetComponent<MeshRenderer>();
				if (mr)
				{
					mr.material.mainTexture = texOn;
				}
			}	
			Physics.IgnoreCollision(c,this.collider);
		}
		
		if(c.name == "Room5_Guard"){
			goodSound.Play();
			roboGuard.GetComponent<TriggeredGuard>().ComeHere(transform.position + new Vector3(30000,0,0));
		}
	}
}
