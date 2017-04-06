using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlGameOver : MonoBehaviour {

	GameObject[] gameOverObjects;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		gameOverObjects = GameObject.FindGameObjectsWithTag("GameOver");
		hideGameOver();
	}

	// Update is called once per frame
	void Update () {

		//uses the p button to pause and unpause the game
		/*if(Input.GetKeyDown(KeyCode.P))
		{
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showGameOver();
			} else if (Time.timeScale == 0){
				Debug.Log ("high");
				Time.timeScale = 1;
				hideGameOver();
			}
		}*/
	}


	//Reloads the Level
	public void Reload(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	//controls the pausing of the scene
	public void pauseControl(){
		if(Time.timeScale == 1)
		{
			Time.timeScale = 0;
			showGameOver();
		} else if (Time.timeScale == 0){
			Time.timeScale = 1;
			hideGameOver();
		}
	}

	//shows objects with ShowOnPause tag
	public void showGameOver(){
		foreach(GameObject g in gameOverObjects){
			g.SetActive(true);
		}
	}

	//hides objects with ShowOnPause tag
	public void hideGameOver(){
		foreach(GameObject g in gameOverObjects){
			g.SetActive(false);
		}
	}

	//loads inputted level
	public void LoadLevel(string level){
		SceneManager.LoadScene (level);
	}
}
