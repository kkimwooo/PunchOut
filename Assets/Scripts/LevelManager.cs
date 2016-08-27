using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static LevelManager Instance { get; private set; }
    public PlayerController playerController;

    public bool isPaused { get; set; }

    public TimeSpan RunningTime { get { return DateTime.UtcNow - started; } }
    private DateTime started;

    void Awake()
    {
        Instance = this;
        isPaused = false;
    }

	void Start ()
    {
        started = DateTime.UtcNow;
	}
	
	void Update () {
	
	}

    void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;

        //TODO: Show Pause UI
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
    }

    public void KillPlayer()
    {
        StartCoroutine(KillPlayerCo());
    }

    private IEnumerator KillPlayerCo()
    {
        playerController.Kill();
        yield return new WaitForSeconds(2f);
        //SceneManager.LoadScene()    
    }
}
