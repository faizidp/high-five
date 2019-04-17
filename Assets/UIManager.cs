﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	public static UIManager instance = null;

	public GameObject gameOverPanel;

	void Awake(){
		instance = this;
	}
	public void OnGameOver(){
		gameOverPanel.SetActive(true);
	}

	public void OnRestartGame(){
		SceneManager.LoadScene(0);
	}
}
