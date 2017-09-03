using UnityEngine;
using System.Collections;

public class StartVolume : MonoBehaviour {
	private MusicManager musicManager;
	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
		if (musicManager) {
            Debug.Log("Music Found!");
			float vol = PlayerPrefsManager.GetMasterVolume();
			musicManager.ChangeVolume (vol);
		}
		else
			Debug.LogWarning ("No music manager found in start scene, cant set volume");
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("CURRENT VOLUME IS " + PlayerPrefsManager.GetMasterVolume().ToString());
	}
}
