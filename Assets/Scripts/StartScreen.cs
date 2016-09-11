﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {

    string jumpSceneName;

	void Start () {
        System.GC.Collect();
        zFoxFadeFilter.instance.FadeIn(Color.black, 1.0f);
	}

    void Button_Play(MenuObject_Button button)
    {
        //PlayerController.initParam = true;
        zFoxFadeFilter.instance.FadeOut(Color.white, 1.0f);
        jumpSceneName = "GameStage";
        Invoke("SceneJump", 1.2f);
    }

    void SceneJump() {
        Debug.Log(string.Format("Start Game : {0}", jumpSceneName));
        SceneManager.LoadScene(jumpSceneName);
    }
}
