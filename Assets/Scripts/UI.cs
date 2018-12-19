using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	public Player player;

	public Text InGameLife;
	public Text InGameScore;
	public GameObject InGameUI;
	public GameObject menu;
	public GameObject GameOver;
	public Text GameOverScore;

	// Use this for initialization
	void Start () {
        Time.timeScale = 0.0f;
	}

	public void onStart()
	{
		menu.SetActive(false);
		InGameUI.SetActive(true);
		Time.timeScale = 1.0f;
	}
	public void onReStart()
	{
		player.resetGameScore ();
		GameOver.SetActive(false);
		menu.SetActive(false);
		InGameUI.SetActive(true);
		Time.timeScale = 1.0f;
	}

	public void resetScoreLives(float lives,float score)
	{
		InGameLife.text = "Lives : " + lives.ToString ();
		InGameScore.text = "Score : " + score.ToString ();
	}

	public void OnGameOver(float score)
	{
		//Show Menu Fater Death
		GameOverScore.text = "Score : " + score.ToString();
		InGameUI.SetActive(false);
		GameOver.SetActive(true);
		Time.timeScale = 0.0f;
	}


}
