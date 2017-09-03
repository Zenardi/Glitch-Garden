using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChange;
	private AudioSource audioSource;

	void Awake(){
		DontDestroyOnLoad (gameObject);
	}

	void Start(){
		audioSource = GetComponent<AudioSource> ();
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
	}
	 


	public void OnLevelWasLoaded (int level) {
		AudioClip levelMusic = levelMusicChange [level];
		if (levelMusic) {
			audioSource.clip = levelMusic;
			audioSource.loop = true;
			audioSource.Play ();
		} else {
			Debug.LogWarning ("Error on load music on level " + level.ToString ());
		}
	}

	public void ChangeVolume(float value){
		audioSource.volume = value;
	}
}
