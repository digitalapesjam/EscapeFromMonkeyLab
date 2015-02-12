/*
	AudioInput.cs
	© Tue Dec  5 15:16:24 CET 2006 Graveck Interactive
	by Jonathan Czeck
*/
using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class AudioInput : MonoBehaviour
{
	private static AudioInput s_Instance = null;
	
	public static AudioInput instance
	{
		get
		{
			if (s_Instance == null)
			{
				s_Instance = FindObjectOfType(typeof(AudioInput)) as AudioInput;
				if (s_Instance == null)
					Debug.Log("Error: There needs to be exactly one AudioInput in the scene.");
			}
			return s_Instance;
		}
	}

	[DllImport ("AudioInput")]
	private static extern int StartListening ();

	[DllImport ("AudioInput")]
	private static extern int StopListening ();

	[DllImport ("AudioInput", EntryPoint="Volume")]
	private static extern float GetVolume ();
	
	public float scale = 100f;
	public float currentVolume = 0f;
	
	void Awake()
	{
		s_Instance = this;
		int result = StartListening();
		if (result != 0)
			Debug.Log("AudioInputPlugin Error: StartListening result: " + result);
		currentVolume = GetVolume();
	}
	
	void OnApplicationQuit()
	{
		int result = StopListening();
		if (result != 0)
			Debug.Log("AudioInputPlugin Error: StopListening result: " + result);
		s_Instance = null;
	}
	
	
	public static float Volume
	{
		get
		{
			if (!s_Instance)
			{
				GameObject audioInputGO = new GameObject("AudioInput Manager");
				AudioInput audioInput = audioInputGO.AddComponent(typeof(AudioInput)) as AudioInput;
				s_Instance = audioInput;
			}
			return Mathf.Clamp(s_Instance.currentVolume * s_Instance.scale, 0f, 10f);
		}
	}
	
	void FixedUpdate()
	{
		currentVolume = GetVolume();
	}
}
