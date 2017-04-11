using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlPause : MonoBehaviour {

	GameObject[] pauseObjects;

	public GameObject texto;

	private GameObject nave;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		hidePaused();

		nave = GameObject.Find ("Nave");

	}

	// Update is called once per frame
	void Update () {

		//uses the p button to pause and unpause the game
		if(Input.GetKeyDown(KeyCode.P))
		{
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			} else if (Time.timeScale == 0){
				Debug.Log ("high");
				Time.timeScale = 1;
				hidePaused();
			}
		}


		//Debug.Log (nave.GetComponent<ControlNave>().alive);

		if (Time.timeScale == 0 &&  nave.GetComponent<ControlNave>().alive== false){
			showPaused ();
			texto.GetComponent<Text> ().text= "GAME OVER";
		}

        if (Time.timeScale == 0 && nave.GetComponent<ControlNave>().victoria == true){
            showPaused();
            texto.GetComponent<Text>().text = "VICTORY";
        }

    }


	//Reloads the Level
	public void Reload(){
		if (Time.timeScale == 0 && nave.GetComponent<ControlNave> ().alive == false) {
			SceneManager.LoadScene("Nivel1");
		} else {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

	}

	//controls the pausing of the scene
	public void pauseControl(){
		if(Time.timeScale == 1)
		{
			Time.timeScale = 0;
			showPaused();
		} else if (Time.timeScale == 0 && nave.GetComponent<ControlNave> ().alive == false){
			SceneManager.LoadScene("Nivel1");
		}else if(Time.timeScale==0) {
			Time.timeScale = 1;
			hidePaused();
		}
	}

	//shows objects with ShowOnPause tag
	public void showPaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(true);
		}
	}

	//hides objects with ShowOnPause tag
	public void hidePaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(false);
		}
	}

	//loads inputted level
	public void LoadLevel(string level){

		//string[] aux = level.Split ('_');


		/*if (aux.Length > 1) {
			Scenes.Load (aux [0], "tipo", aux [1]);
		} else {*/
			SceneManager.LoadScene (level);
		//}
	}
}
