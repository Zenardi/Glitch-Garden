using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameTimer : MonoBehaviour {

    private Slider slider;
    private AudioSource audioSource;
    public float levelSeconds = 100f;
    private bool isEndOfLevel = false;
    private LevelManager levelManager;
    private GameObject winLabel;

	// Use this for initialization
	void Start ()
    {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        winLabel = GameObject.Find("You Win");

        FindYouWin();
        winLabel.SetActive(false);
    }

    private void FindYouWin()
    {
        if (!winLabel)
            Debug.LogWarning("Create `You Win` Object");


    }

    // Update is called once per frame
    void Update () {
        slider.value = Time.timeSinceLevelLoad / levelSeconds;

        if(Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel)
        {
            HandleWinCondition();
        }
    }

    private void HandleWinCondition()
    {
        DestroyAllTagObjects();
        audioSource.Play();
        winLabel.SetActive(true);
        Invoke("LoadNextLevel", audioSource.clip.length);
        isEndOfLevel = true;
    }

    /// <summary>
    /// Destroy all objects with DestroyOnWin tag
    /// </summary>
    private void DestroyAllTagObjects()
    {
        GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag("DestroyOnWin");

        foreach(GameObject tagged in taggedObjectArray)
        {
            Destroy(tagged);
        }
    }

    void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }
}
