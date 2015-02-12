using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public float CameraActivationThreshold;
	
	const float timeMultiplier = 2.0f;
	
	// !!! SIZE OF THE ROOM !!!
	// !!! MUST BE FIXED WITH THE FINAL SIZE !!!
	const float roomWidth = 12650.0f;
	const float roomHeight = 1.0f;
	const float roomDepth = 800.0f;
	
	private int curRoom = 0;
	private float roomOffset = 0.0f;
	const int maxRoom = 4;
	
	private bool isTransitioning = false;
	private int transitionDirection = 0;
	
	private Vector3 baseOffset = new Vector3(0,2387, -5360);

    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Camera cam = GetComponent<Camera>();
		if (cam == null) return;
		
		if (player)
		{
			int newRoom = (int)(0.5f + player.GetComponent<Transform>().position.x / roomWidth);
			if (newRoom == curRoom + 1)
				NextRoom();
			else if (newRoom == curRoom - 1)
				PrevRoom();
		} 
		
		if (isTransitioning)
		{
			roomOffset += Time.deltaTime * timeMultiplier;
			if (roomOffset > 1.0f) 
			{ 
				roomOffset = 0.0f;
				curRoom += transitionDirection;
				isTransitioning = false;
			}
		}
		
		float sinOffset = 0.5f * (1.0f + Mathf.Sin(- 1.5707f + roomOffset * 3.1415f));		
		cam.transform.position = baseOffset + new Vector3(roomWidth*(curRoom+sinOffset*transitionDirection), 0.0f, 0.0f); 
		
		Quaternion lookDown = Quaternion.Euler(0.0f, 0, 0);
		cam.transform.rotation = lookDown;
		
	}
	
	public void NextRoom()
	{
		if (!isTransitioning && curRoom < maxRoom-1) 
		{
			isTransitioning = true;
			transitionDirection = 1;
			roomOffset = 0.0f;

		}
	}
	
	public void PrevRoom()
	{
		if (!isTransitioning && curRoom > 0) 
		{
			isTransitioning = true;
			transitionDirection = -1;
			roomOffset = 0.0f;
		}
	}
}
