using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static LevelManager Instance { get; private set; }
    public TimeSpan RunningTime { get { return DateTime.UtcNow - started; } }
    private DateTime started;

    void Awake()
    {
        Instance = this;
    }

	void Start ()
    {
        started = DateTime.UtcNow;
	}
	
	void Update () {
	
	}

    void OnApplicationPause(bool flag)
    {
        if (flag)
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

    }

    public void ResumeGame()
    {

    }

    public void KillPlayer()
    {
        StartCoroutine(KillPlayerCo());
    }

    private IEnumerator KillPlayerCo()
    {
        //PlayerController.Kill()
        yield return new WaitForSeconds(2f);
        //SceneManager.LoadScene()    
    }
}
