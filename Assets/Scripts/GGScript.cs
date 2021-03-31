// Decompile from assembly: Assembly-CSharp.dll

using System;
using UnityEngine;

public class GGScript : MonoBehaviour
{
	public MeshRenderer meshDelay;

	private bool isCatched;

	public AudioClip CoinSound;

	public GameObject Music;

	public GameObject panel;

	public bool CanRotate = true;

	public GameObject camLock;

	public GameObject TLP;

	private bool paused;

	public bool lockEsk;

	public AudioSource MuteMusic;

	private void Start()
	{
		this.meshDelay = base.GetComponent<MeshRenderer>();
		this.panel.SetActive(false);
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
		this.lockEsk = false;
		this.MuteMusic.Play();
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	private void OnTriggerEnter(Collider coin)
	{
		if (coin.tag == "Player" && !this.isCatched)
		{
			this.lockEsk = true;
			this.MuteMusic.Stop();
			base.GetComponent<AudioSource>().PlayOneShot(this.CoinSound);
			this.meshDelay.enabled = false;
			this.isCatched = true;
			Time.timeScale = 0f;
			this.paused = true;
			this.panel.SetActive(true);
			this.CanRotate = false;
		}
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.lockState = CursorLockMode.None;
	}

	private void Update()
	{
		if (UnityEngine.Object.FindObjectOfType<TimeCounter>().hz == 0)
		{
			this.meshDelay.enabled = true;
			this.isCatched = false;
		}
	}
}
