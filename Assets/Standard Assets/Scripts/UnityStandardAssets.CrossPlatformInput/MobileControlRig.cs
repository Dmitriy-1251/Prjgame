// Decompile from assembly: Assembly-CSharp-firstpass.dll

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	[ExecuteInEditMode]
	public class MobileControlRig : MonoBehaviour
	{
		private void OnEnable()
		{
			this.CheckEnableControlRig();
		}

		private void Start()
		{
			if (UnityEngine.Object.FindObjectOfType<EventSystem>() == null)
			{
				GameObject expr_17 = new GameObject("EventSystem");
				expr_17.AddComponent<EventSystem>();
				expr_17.AddComponent<StandaloneInputModule>();
			}
		}

		private void CheckEnableControlRig()
		{
			this.EnableControlRig(false);
		}

		private void EnableControlRig(bool enabled)
		{
			using (IEnumerator enumerator = base.transform.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					((Transform)enumerator.Current).gameObject.SetActive(enabled);
				}
			}
		}
	}
}
