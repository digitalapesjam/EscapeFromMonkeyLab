using UnityEngine;
using System.Collections;

public class GameLoopScript: MonoBehaviour {

	abstract class BaseState {
		public abstract void Reset();
		public abstract BaseState Logic();
		public BaseState Update(){
			BaseState _out = Logic();
			if(_out != this){
				_out.Reset();
			}
			return _out;
		}
	}
	
	class GameState : BaseState {
		public bool hasDied = false;
		public override void Reset(){}
		public override BaseState Logic(){
			if(hasDied){
				return new PlayEndState();
			}
			return this;
		}
	}
	class PlayEndState : BaseState {
		int maxIter = 4;
		int framePerIter = 35;
		int curFrame = 0;
		BlurEffect eff;
		public override void Reset(){
			eff = Camera.main.GetComponent<BlurEffect>();
			GameObject.FindWithTag("Player").GetComponents<AudioSource>()[3].Play();
			if(eff==null) return;
			eff.enabled = true;
			eff.blurSpread = 2.0f;
			eff.iterations = 0;
			curFrame = 0;
		}
		public override BaseState Logic(){
			if(eff==null){
				if(curFrame < 200){curFrame++; return this;}
				return new RestartState();
			}
			if(curFrame==framePerIter){
				if(eff.iterations==maxIter){
					return new RestartState();
				}else{
					eff.iterations++;
					curFrame=0;
				}
			}else{
				curFrame++;
			}
			return this;
		}
	}
	
	class RestartState : BaseState {
		public override void Reset(){}
		public override BaseState Logic(){
			Application.LoadLevel(Application.loadedLevel);
			return this;
		}
	}
	
	public int Lives = 3;
	BaseState mystate = new GameState();
	PlayerHide hideInfo;
	
	// Use this for initialization
	void Start () {
		hideInfo = GetComponent<PlayerHide>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Escape))
			Application.Quit();
		mystate = mystate.Update();
	}
	
	void OnTriggerEnter(Collider c){
		//Die();
		//Restart();
		//Debug.Log("colliding with a " + c.gameObject.tag);
		if(c.gameObject.tag=="Enemy" && !hideInfo.IsHiding() && typeof(GameState)==mystate.GetType()){
			//Debug.Log("youdddaaai");
			Component comp = GetComponent("PlatformerController");
			comp.SendMessage("SetControllable",false);
			((GameState)mystate).hasDied=true;
//			Application.LoadLevel(Application.loadedLevel);
			GetComponent("GameOverGUI").SendMessage("Enable");
			GetComponent<MeshRenderer>().enabled = true;
		}
	}
}
