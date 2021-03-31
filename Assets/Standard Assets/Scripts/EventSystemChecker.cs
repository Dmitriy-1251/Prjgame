// Decompile from assembly: Assembly-CSharp-firstpass.dll

using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemChecker : MonoBehaviour
{
	private void Awake()
	{
		if (!UnityEngine.Object.FindObjectOfType<EventSystem>())
		{
			GameObject expr_16 = new GameObject("EventSystem");
			expr_16.AddComponent<EventSystem>();
			expr_16.AddComponent<StandaloneInputModule>().forceModuleActive = true;
		}
	}
}
