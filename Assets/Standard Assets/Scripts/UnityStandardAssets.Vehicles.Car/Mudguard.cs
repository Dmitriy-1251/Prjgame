// Decompile from assembly: Assembly-CSharp-firstpass.dll

using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	public class Mudguard : MonoBehaviour
	{
		public CarController carController;

		private Quaternion m_OriginalRotation;

		private void Start()
		{
			this.m_OriginalRotation = base.transform.localRotation;
		}

		private void Update()
		{
			base.transform.localRotation = this.m_OriginalRotation * Quaternion.Euler(0f, this.carController.CurrentSteerAngle, 0f);
		}
	}
}
