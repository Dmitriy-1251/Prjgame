// Decompile from assembly: Assembly-CSharp.dll

using System;
using UnityEngine;

public class TP : MonoBehaviour
{
	public GameObject TLP;

	public void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player")
		{
			col.transform.position = this.TLP.transform.position;
		}
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
