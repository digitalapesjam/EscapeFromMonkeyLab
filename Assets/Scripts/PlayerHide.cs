using UnityEngine;
using System.Collections;

public class PlayerHide : MonoBehaviour {

	private float hideout_x=0;
	private float hideout_z=0;
	
	abstract class BaseState {
		public BaseState next = null;
		public PlayerHide t = null;
		public abstract void Reset();
		public abstract BaseState Update();
	}
	class HidingState : BaseState {
		//int maxFr = 400;
		//int curFr = 0;
		public override void Reset(){
			if(next==null){
				next=new NormalState();
				next.t = t;
			}
			//curFr = 0;
			t.StartHiding();
		}
		public override BaseState Update() {
			if(!Input.GetKey(KeyCode.UpArrow)){
				next.Reset();
				return next;
			}
			//curFr++;
			//if(curFr==maxFr){
			//	next.Reset();
			//	return next;
			//}
			return this;
		}
	}
	class WaitState : BaseState {
		int maxFr = 10;
		int curFr = 0;
		public override void Reset(){
			if(next==null){
				next=new NormalState();
				next.t = t;
			}
			curFr = 0;
			t.StartWait();
		}
		public override BaseState Update() {
			curFr++;
			if(curFr==maxFr){
				next.Reset();
				return next;
			}
			return this;
		}
	}
	class NormalState : BaseState {
		public bool canHide = false;
		public override void Reset() {
			if(next==null){
				next=new HidingState();
				next.t = t;
			}
			t.StartNormal();
		}
		public override BaseState Update() {
			if(Input.GetKeyDown(KeyCode.UpArrow) && t.canHide){
				next.Reset();
				return next;
			}
			return this;
		}
	}
	
	BaseState mystate;
	public bool canHide;
	// Use this for initialization
	void Start () {
		canHide = false;
		mystate = new NormalState();
		mystate.t = this;
		mystate.Reset();
	}
	
	// Update is called once per frame
	void Update () {
		mystate = mystate.Update();
	}
	
	void OnTriggerEnter(Collider other)
	{
		//Debug.Log(other.gameObject.tag);
		if (other.gameObject.tag == "Hideout"){
			canHide = true;
			hideout_x = other.gameObject.transform.position.x;
			hideout_z = other.bounds.max.z;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Hideout")
			canHide = false;
	}
	
	void StartHiding(){
		GameObject pRef = GameObject.Find("PlayerRef");
		GameObject sRef = GameObject.Find("PlayerShadow");
		
		
		Vector3 pos = pRef.transform.position;
		pos.z = hideout_z;//sRef.transform.position.z;
		pos.x = 	hideout_x;
		sRef.transform.position = pos;
		sRef.renderer.enabled = true;
		Component comp = GetComponent("PlatformerController");
		comp.SendMessage("SetControllable",false);
		
		AudioSource heartBeat = GetComponents<AudioSource>()[2];
		heartBeat.Play();
	}
	void StartNormal(){
		GameObject.Find("PlayerShadow").renderer.enabled = false;
		Component comp = GetComponent("PlatformerController");
		comp.SendMessage("SetControllable",true);

		AudioSource heartBeat = GetComponents<AudioSource>()[2];
		heartBeat.Stop();			
	}
	void StartWait(){
		//just swapped with StartNormal...
	}
	
	bool IsNormal() {
		return mystate.GetType() == typeof(NormalState);
	}
	public bool IsHiding() {
		return mystate.GetType() == typeof(HidingState);
	}
}
