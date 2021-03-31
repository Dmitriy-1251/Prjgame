// Decompile from assembly: Assembly-CSharp-firstpass.dll

using System;
using UnityEngine;

namespace UnityStandardAssets.Effects
{
	public class ParticleSystemMultiplier : MonoBehaviour
	{
		public float multiplier = 1f;

		private void Start()
		{
			ParticleSystem[] componentsInChildren = base.GetComponentsInChildren<ParticleSystem>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				ParticleSystem expr_0E = componentsInChildren[i];
				ParticleSystem.MainModule main = expr_0E.main;
				main.startSizeMultiplier *= this.multiplier;
				main.startSpeedMultiplier *= this.multiplier;
				main.startLifetimeMultiplier *= Mathf.Lerp(this.multiplier, 1f, 0.5f);
				expr_0E.Clear();
				expr_0E.Play();
			}
		}
	}
}
