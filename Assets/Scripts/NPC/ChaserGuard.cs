using UnityEngine;
using System.Collections;
using System.Timers;

public class ChaserGuard : MonoBehaviour {

	public int ChasingTimeOut;
	public int MinX = 0;
	public int MaxX = 0;
	public float Speed = 100;
	
	Vector3 direction;
	bool chasing=false;
	Timer timer;
	System.Random random;
	
	// Use this for initialization
	void Start () {
		direction = new Vector3(-1,0,0);
		chasing = false;
		timer = new Timer(ChasingTimeOut);
		timer.Elapsed +=	 HandleTimerElapsed;
		random = new System.Random();
	}

	void HandleTimerElapsed (object sender, ElapsedEventArgs e)
	{
		timer.Stop();
		chasing = false;
		direction.x = (float)(random.NextDouble()-0.5);
		direction.Normalize();			
	}
	
	// Update is called once per frameChaserGuard : Mono
	void Update () {
		direction.Normalize();
		
		CharacterController c = GameObject.Find("PlayerRef").GetComponent<CharacterController>();
		//AudioSource s = GetComponent<AudioSource>();
		
		if(Mathf.Abs(c.velocity.x) > 100) {
			chasing = true;
			timer.Stop();
		} else if (chasing && !timer.Enabled) {
			timer.Start();
		}
		
		if (chasing){
			direction.x =  GameObject.Find("PlayerRef").transform.position.x - transform.position.x;
			if (Mathf.Abs(direction.x) > Speed*4) {
				direction.Normalize();
				transform.position += direction*Speed*4;
			} else{
				transform.position += direction;
			}
			
		} else {
		
			if (transform.position.x >= MaxX || transform.position.x <= MinX){
				
				direction.x = -direction.x;
			} 
			
			if (transform.position.x >= MaxX)
				transform.position = new Vector3(MaxX,transform.position.y,transform.position.z);
			
			if (transform.position.x <= MinX)
				transform.position = new Vector3(MinX,transform.position.y,transform.position.z);
			
			transform.position += direction*Speed;
		}
			
		
	}
}
