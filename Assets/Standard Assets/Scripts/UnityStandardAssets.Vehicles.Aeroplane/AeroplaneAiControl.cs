// Decompile from assembly: Assembly-CSharp-firstpass.dll

using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneAiControl : MonoBehaviour
	{
		[SerializeField]
		private float m_RollSensitivity = 0.2f;

		[SerializeField]
		private float m_PitchSensitivity = 0.5f;

		[SerializeField]
		private float m_LateralWanderDistance = 5f;

		[SerializeField]
		private float m_LateralWanderSpeed = 0.11f;

		[SerializeField]
		private float m_MaxClimbAngle = 45f;

		[SerializeField]
		private float m_MaxRollAngle = 45f;

		[SerializeField]
		private float m_SpeedEffect = 0.01f;

		[SerializeField]
		private float m_TakeoffHeight = 20f;

		[SerializeField]
		private Transform m_Target;

		private AeroplaneController m_AeroplaneController;

		private float m_RandomPerlin;

		private bool m_TakenOff;

		private void Awake()
		{
			this.m_AeroplaneController = base.GetComponent<AeroplaneController>();
			this.m_RandomPerlin = UnityEngine.Random.Range(0f, 100f);
		}

		public void Reset()
		{
			this.m_TakenOff = false;
		}

		private void FixedUpdate()
		{
			if (this.m_Target != null)
			{
				Vector3 position = this.m_Target.position + base.transform.right * (Mathf.PerlinNoise(Time.time * this.m_LateralWanderSpeed, this.m_RandomPerlin) * 2f - 1f) * this.m_LateralWanderDistance;
				Vector3 vector = base.transform.InverseTransformPoint(position);
				float num = Mathf.Atan2(vector.x, vector.z);
				float num2 = (Mathf.Clamp(-Mathf.Atan2(vector.y, vector.z), -this.m_MaxClimbAngle * 0.0174532924f, this.m_MaxClimbAngle * 0.0174532924f) - this.m_AeroplaneController.PitchAngle) * this.m_PitchSensitivity;
				float num3 = Mathf.Clamp(num, -this.m_MaxRollAngle * 0.0174532924f, this.m_MaxRollAngle * 0.0174532924f);
				float num4 = 0f;
				float num5 = 0f;
				if (!this.m_TakenOff)
				{
					if (this.m_AeroplaneController.Altitude > this.m_TakeoffHeight)
					{
						this.m_TakenOff = true;
					}
				}
				else
				{
					num4 = num;
					num5 = -(this.m_AeroplaneController.RollAngle - num3) * this.m_RollSensitivity;
				}
				float num6 = 1f + this.m_AeroplaneController.ForwardSpeed * this.m_SpeedEffect;
				num5 *= num6;
				num2 *= num6;
				num4 *= num6;
				this.m_AeroplaneController.Move(num5, num2, num4, 0.5f, false);
				return;
			}
			this.m_AeroplaneController.Move(0f, 0f, 0f, 0f, false);
		}

		public void SetTarget(Transform target)
		{
			this.m_Target = target;
		}
	}
}
