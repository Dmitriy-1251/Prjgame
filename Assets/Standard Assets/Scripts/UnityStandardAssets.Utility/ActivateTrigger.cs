// Decompile from assembly: Assembly-CSharp-firstpass.dll

using System;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	public class ActivateTrigger : MonoBehaviour
	{
		public enum Mode
		{
			Trigger,
			Replace,
			Activate,
			Enable,
			Animate,
			Deactivate
		}

		public ActivateTrigger.Mode action = ActivateTrigger.Mode.Activate;

		public UnityEngine.Object target;

		public GameObject source;

		public int triggerCount = 1;

		public bool repeatTrigger;

		private void DoActivateTrigger()
		{
			this.triggerCount--;
			if (this.triggerCount == 0 || this.repeatTrigger)
			{
				UnityEngine.Object expr_31 = this.target ?? base.gameObject;
				Behaviour behaviour = expr_31 as Behaviour;
				GameObject gameObject = expr_31 as GameObject;
				if (behaviour != null)
				{
					gameObject = behaviour.gameObject;
				}
				switch (this.action)
				{
				case ActivateTrigger.Mode.Trigger:
					if (gameObject != null)
					{
						gameObject.BroadcastMessage("DoActivateTrigger");
						return;
					}
					break;
				case ActivateTrigger.Mode.Replace:
					if (this.source != null && gameObject != null)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.source, gameObject.transform.position, gameObject.transform.rotation);
						UnityEngine.Object.DestroyObject(gameObject);
						return;
					}
					break;
				case ActivateTrigger.Mode.Activate:
					if (gameObject != null)
					{
						gameObject.SetActive(true);
						return;
					}
					break;
				case ActivateTrigger.Mode.Enable:
					if (behaviour != null)
					{
						behaviour.enabled = true;
						return;
					}
					break;
				case ActivateTrigger.Mode.Animate:
					if (gameObject != null)
					{
						gameObject.GetComponent<Animation>().Play();
						return;
					}
					break;
				case ActivateTrigger.Mode.Deactivate:
					if (gameObject != null)
					{
						gameObject.SetActive(false);
					}
					break;
				default:
					return;
				}
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			this.DoActivateTrigger();
		}
	}
}
