// Decompile from assembly: Assembly-CSharp-firstpass.dll

using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
	[RequireComponent(typeof(CarController))]
	public class CarUserControl : MonoBehaviour
	{
		private CarController m_Car;

		private void Awake()
		{
			this.m_Car = base.GetComponent<CarController>();
		}

		private void FixedUpdate()
		{
			float axis = CrossPlatformInputManager.GetAxis("Horizontal");
			float axis2 = CrossPlatformInputManager.GetAxis("Vertical");
			float axis3 = CrossPlatformInputManager.GetAxis("Jump");
			this.m_Car.Move(axis, axis2, axis2, axis3);
		}
	}
}
