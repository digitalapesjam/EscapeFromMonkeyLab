using UnityEngine;
using System.Collections;

public class SpriteAnimator : MonoBehaviour {

	public Texture2D[] frames;    // Set this from the inspector
	const float frameTime = 0.01f; 
	
	float lastFrameTime = 0.0f;
	float lastAnimationFrame; 
	int currFrame = 0;
	
	bool isAnimating = false;

	// Use this for initialization
	void Start () 
	{	
		lastFrameTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		GameObject playerRef = GameObject.Find("PlayerRef");
		CharacterController c = playerRef.GetComponent<CharacterController>();
		if (c.velocity.x > 100)
			Start(+1);
		else if (c.velocity.x < -100)
			Start(-1);
		else if (Mathf.Abs(c.velocity.x) <= 100)
			Stop();
		
		MeshRenderer mr = GetComponent<MeshRenderer>();
		if (mr == null) return;

		if (isAnimating)
		{
			float elapsedTime = Time.time - lastFrameTime;
			currFrame = ((int)(elapsedTime / frameTime)) % frames.Length;
			mr.material.mainTexture = frames[currFrame];
			
			float elapsedAnimationTime = Time.time - lastAnimationFrame;
			lastAnimationFrame += elapsedAnimationTime;			
		}
		else if (currFrame != 0)
		{
			float elapsedTime = Time.time - lastFrameTime;
			currFrame = ((int)(elapsedTime / frameTime));
			if (currFrame >= frames.Length) currFrame = 0;			
		}
		
		//Debug.Log(currFrame);
		
		/*if ((Time.time - lastFrameTime) >= frame		transform.localScale =Time) {
        	currFrame = (currFrame + 1) % frames.Length;
        	renderer.material.mainTexture = frames[currFrame];
    	} */
	}
	
	// +1 for right, -1 for left
	public void Start(int nDir)
	{
		isAnimating = true;
		
		transform.localScale = new Vector3(-nDir * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
		
		lastAnimationFrame = Time.time;	
	}
	
	public void Stop()
	{
		isAnimating = false;
	}
}
