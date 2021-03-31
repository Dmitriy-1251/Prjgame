// Decompile from assembly: Assembly-CSharp-firstpass.dll

using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	public class AeroplaneControlSurfaceAnimator : MonoBehaviour
	{
		[Serializable]
		public class ControlSurface
		{
			public enum Type
			{
				Aileron,
				Elevator,
				Rudder,
				RuddervatorNegative,
				RuddervatorPositive
			}

			public Transform transform;

			public float amount;

			public AeroplaneControlSurfaceAnimator.ControlSurface.Type type;

			[HideInInspector]
			public Quaternion originalLocalRotation;
		}

		[SerializeField]
		private float m_Smoothing = 5f;

		[SerializeField]
		private AeroplaneControlSurfaceAnimator.ControlSurface[] m_ControlSurfaces;

		private AeroplaneController m_Plane;

		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			AeroplaneControlSurfaceAnimator.ControlSurface[] controlSurfaces = this.m_ControlSurfaces;
			for (int i = 0; i < controlSurfaces.Length; i++)
			{
				AeroplaneControlSurfaceAnimator.ControlSurface expr_1A = controlSurfaces[i];
				expr_1A.originalLocalRotation = expr_1A.transform.localRotation;
			}
		}

		private void Update()
		{
			AeroplaneControlSurfaceAnimator.ControlSurface[] controlSurfaces = this.m_ControlSurfaces;
			for (int i = 0; i < controlSurfaces.Length; i++)
			{
				AeroplaneControlSurfaceAnimator.ControlSurface controlSurface = controlSurfaces[i];
				switch (controlSurface.type)
				{
				case AeroplaneControlSurfaceAnimator.ControlSurface.Type.Aileron:
				{
					Quaternion rotation = Quaternion.Euler(controlSurface.amount * this.m_Plane.RollInput, 0f, 0f);
					this.RotateSurface(controlSurface, rotation);
					break;
				}
				case AeroplaneControlSurfaceAnimator.ControlSurface.Type.Elevator:
				{
					Quaternion rotation2 = Quaternion.Euler(controlSurface.amount * -this.m_Plane.PitchInput, 0f, 0f);
					this.RotateSurface(controlSurface, rotation2);
					break;
				}
				case AeroplaneControlSurfaceAnimator.ControlSurface.Type.Rudder:
				{
					Quaternion rotation3 = Quaternion.Euler(0f, controlSurface.amount * this.m_Plane.YawInput, 0f);
					this.RotateSurface(controlSurface, rotation3);
					break;
				}
				case AeroplaneControlSurfaceAnimator.ControlSurface.Type.RuddervatorNegative:
				{
					float num = this.m_Plane.YawInput - this.m_Plane.PitchInput;
					Quaternion rotation4 = Quaternion.Euler(0f, 0f, controlSurface.amount * num);
					this.RotateSurface(controlSurface, rotation4);
					break;
				}
				case AeroplaneControlSurfaceAnimator.ControlSurface.Type.RuddervatorPositive:
				{
					float num2 = this.m_Plane.YawInput + this.m_Plane.PitchInput;
					Quaternion rotation5 = Quaternion.Euler(0f, 0f, controlSurface.amount * num2);
					this.RotateSurface(controlSurface, rotation5);
					break;
				}
				}
			}
		}

		private void RotateSurface(AeroplaneControlSurfaceAnimator.ControlSurface surface, Quaternion rotation)
		{
			Quaternion b = surface.originalLocalRotation * rotation;
			surface.transform.localRotation = Quaternion.Slerp(surface.transform.localRotation, b, this.m_Smoothing * Time.deltaTime);
		}
	}
}
