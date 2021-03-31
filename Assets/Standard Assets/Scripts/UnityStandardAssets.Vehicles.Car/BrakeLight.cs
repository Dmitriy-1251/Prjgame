// Decompile from assembly: Assembly-CSharp-firstpass.dll

using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	public class BrakeLight : MonoBehaviour
	{
		public CarController car;

		private Renderer m_Renderer;

		private void Start()
		{
			this.m_Renderer = base.GetComponent<Renderer>();
		}

		private void Update()
		{
			this.m_Renderer.enabled = (this.car.BrakeInput > 0f);
		}
	}
}
