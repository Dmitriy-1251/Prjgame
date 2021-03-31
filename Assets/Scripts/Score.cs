// Decompile from assembly: Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public Text diecount;

	public int DieCounter;

	public AudioClip DieSound;

	private void OnTriggerEnter(Collider DieCollider)
	{
		if (DieCollider.tag == "Player")
		{
			this.DieCounter++;
			base.GetComponent<AudioSource>().PlayOneShot(this.DieSound);
		}
	}

	private void Update()
	{
		if (this.DieCounter != 0)
		{
			this.diecount.enabled = true;
			this.diecount.text = "Your died " + this.DieCounter + " times";
			return;
		}
		this.diecount.enabled = false;
	}
}
