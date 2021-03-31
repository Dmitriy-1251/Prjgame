// Decompile from assembly: Assembly-CSharp.dll

using System;
using UnityEngine;

public class PAuseScript : MonoBehaviour
{
	private Collider col;

	public bool NG;

	public GameObject camLock;

	private bool paused;

	public GameObject panel;

	public GameObject TLP;

	public Transform control;

	public bool CanRotate = true;

	public void QuitGame()
	{
		Application.Quit();
	}

	public void RETURN()
	{
		Time.timeScale = 1f;
		this.paused = false;
		this.panel.SetActive(false);
		this.CanRotate = true;
		Cursor.visible = false;
	}

	public void NewGame()
	{
		this.camLock.transform.position = this.TLP.transform.position;
		Time.timeScale = 1f;
		this.paused = false;
		this.panel.SetActive(false);
		UnityEngine.Object.FindObjectOfType<ScorePlayer>().Score = 0;
		UnityEngine.Object.FindObjectOfType<CoinCatch>().BestScoreCoins = 0;
		UnityEngine.Object.FindObjectOfType<CoinCatch>().BestScoreCoinsText.enabled = false;
		UnityEngine.Object.FindObjectOfType<Score>().DieCounter = 0;
		UnityEngine.Object.FindObjectOfType<TimeCounter>().hz = 0;
		this.CanRotate = true;
		Cursor.visible = false;
	}

	private void Start()
	{
		this.panel.SetActive(false);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) && !UnityEngine.Object.FindObjectOfType<GGScript>().lockEsk)
		{
			if (!this.paused)
			{
				Time.timeScale = 0f;
				this.paused = true;
				this.panel.SetActive(true);
				this.CanRotate = false;
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.Confined;
				return;
			}
			Time.timeScale = 1f;
			this.paused = false;
			this.panel.SetActive(false);
			this.CanRotate = true;
			Cursor.visible = false;
		}
	}
}
