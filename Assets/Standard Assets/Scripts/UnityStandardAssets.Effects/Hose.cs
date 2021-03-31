// Decompile from assembly: Assembly-CSharp-firstpass.dll

using System;
using UnityEngine;

namespace UnityStandardAssets.Effects
{
	public class Hose : MonoBehaviour
	{
		public float maxPower = 20f;

		public float minPower = 5f;

		public float changeSpeed = 5f;

		public ParticleSystem[] hoseWaterSystems;

		public Renderer systemRenderer;

		private float m_Power;

		private void Update()
		{
			this.m_Power = Mathf.Lerp(this.m_Power, Input.GetMouseButton(0) ? this.maxPower : this.minPower, Time.deltaTime * this.changeSpeed);
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				this.systemRenderer.enabled = !this.systemRenderer.enabled;
			}
			ParticleSystem[] array = this.hoseWaterSystems;
			for (int i = 0; i < array.Length; i++)
			{
				ParticleSystem expr_63 = array[i];
				expr_63.main.startSpeed = this.m_Power;
				expr_63.emission.enabled = (this.m_Power > this.minPower * 1.1f);
			}
		}
	}
}
