using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VALUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";

	public static void SetMasterVolume(float volume){
		if (volume > 0f && volume <= 1.0f) {
			PlayerPrefs.SetFloat (MASTER_VALUME_KEY, volume);
		} else {
			Debug.Log ("Master Volume Out Of range.");
		}

	}

	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat (MASTER_VALUME_KEY);
	}

	public static void UnlockLevel(int level){
		if(level <= Application.levelCount - 1){
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(),1);
		}else{
			Debug.Log("Trying to unlock a invalid level.");
		}
	}

	public static bool isLevelUnlocked(int level){
		int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
		bool isLevelUnlocked = (levelValue == 1);

		if(level < Application.levelCount - 1){
			return isLevelUnlocked;
		}else{
			Debug.Log("Trying to query a level not in build order.");
			return false;
		}
	}

	public static void SetDifficulty(float diff){
		if (diff >= 0f && diff <= 3f) {
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, diff);
		} else {
			Debug.Log ("Difficulty out of Range.");
		}
	}

	public static float GetDifficulty(){
		return PlayerPrefs.GetFloat (DIFFICULTY_KEY);
	}
}
