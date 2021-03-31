// Decompile from assembly: Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
	public int hz;

	public float timer;

	public Text timerofgame;

	public bool onDeath;

	private void Start()
	{
	}

	private void Update()
	{
		this.timerofgame.text = string.Concat(this.hz);
		if (!this.onDeath)
		{
			this.timer += Time.deltaTime;
			if (this.timer > 1f)
			{
				this.hz++;
				this.timer = 0f;
			}
		}
	}

	private void OnTriggerEnter(Collider DieCollider)
	{
		if (DieCollider.tag == "Floor")
		{
			this.hz = 0;
		}
	}
}
