// Decompile from assembly: Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.UI;

public class ScorePlayer : MonoBehaviour
{
	public int Score;

	public int Coins;

	public Text scoreonview;

	private void Update()
	{
		this.scoreonview.text = "Your score " + this.Score + " points";
	}
}
