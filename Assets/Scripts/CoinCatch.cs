// Decompile from assembly: Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.UI;

public class CoinCatch : MonoBehaviour
{
	public int scoreBoost = 10;

	public GameObject Money;

	public AudioClip CoinSound;

	public int BestScoreCoins;

	public Text BestScoreCoinsText;

	private MeshRenderer meshDelay;

	private bool isCatched;

	private void Start()
	{
		this.meshDelay = base.GetComponent<MeshRenderer>();
	}

	private void OnTriggerEnter(Collider coin)
	{
		if (coin.tag == "Player" && !this.isCatched)
		{
			UnityEngine.Object.FindObjectOfType<ScorePlayer>().Score += this.scoreBoost;
			base.GetComponent<AudioSource>().PlayOneShot(this.CoinSound);
			this.meshDelay.enabled = false;
			this.isCatched = true;
		}
	}

	private void Update()
	{
		if (UnityEngine.Object.FindObjectOfType<TimeCounter>().hz == 0)
		{
			if (this.BestScoreCoins < UnityEngine.Object.FindObjectOfType<ScorePlayer>().Score)
			{
				this.BestScoreCoinsText.enabled = true;
				this.BestScoreCoins = UnityEngine.Object.FindObjectOfType<ScorePlayer>().Score;
				this.BestScoreCoinsText.text = "Your best score " + this.BestScoreCoins + " points";
			}
			UnityEngine.Object.FindObjectOfType<ScorePlayer>().Score = 0;
			this.meshDelay.enabled = true;
			this.isCatched = false;
		}
	}
}
