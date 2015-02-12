using UnityEngine;
using System.Collections;

public class OpenDoorScript : MonoBehaviour {
    Animation openAnimation;
    
    GameObject player;
    Transform door;

    public float DoorActivationThreshold;
	// Use this for initialization
	void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        openAnimation = gameObject.GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () 
    {
		/*if (transform.position.x - player.transform.position.x < DoorActivationThreshold+DoorActivationThreshold/5f && transform.position.x - player.transform.position.x > 0)
			Camera.main.GetComponent<CameraControl>().NextRoom();*/
		
		/*if (player.transform.position.x - transform.position.x < DoorActivationThreshold+DoorActivationThreshold/5f && player.transform.position.x - transform.position.x > 0)
			Camera.main.GetComponent<CameraControl>().PrevRoom();*/
		// if (player.blablabla) s'incula.
		
        if (!openAnimation.isPlaying)
        {
            float distance = gameObject.transform.position.x - player.transform.position.x;
            if (distance > -1 && distance <= DoorActivationThreshold)
            {
                openAnimation.Play();
				player.transform.position += new Vector3((gameObject.transform.position.x - player.transform.position.x)*2f,0,0);
            }
        }
        // FUCK THE SYSTEM FUCK THE SYSTEM
	}
}
