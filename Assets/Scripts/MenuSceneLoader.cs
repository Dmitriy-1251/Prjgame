// Decompile from assembly: Assembly-CSharp.dll

using System;
using UnityEngine;

public class MenuSceneLoader : MonoBehaviour
{
	public GameObject menuUI;

	private GameObject m_Go;

	private void Awake()
	{
		if (this.m_Go == null)
		{
			this.m_Go = UnityEngine.Object.Instantiate<GameObject>(this.menuUI);
		}
	}
}
