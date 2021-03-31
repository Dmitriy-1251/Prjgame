// Decompile from assembly: Assembly-CSharp-firstpass.dll

using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
	public class Camera2DFollow : MonoBehaviour
	{
		public Transform target;

		public float damping = 1f;

		public float lookAheadFactor = 3f;

		public float lookAheadReturnSpeed = 0.5f;

		public float lookAheadMoveThreshold = 0.1f;

		private float m_OffsetZ;

		private Vector3 m_LastTargetPosition;

		private Vector3 m_CurrentVelocity;

		private Vector3 m_LookAheadPos;

		private void Start()
		{
			this.m_LastTargetPosition = this.target.position;
			this.m_OffsetZ = (base.transform.position - this.target.position).z;
			base.transform.parent = null;
		}

		private void Update()
		{
			float x = (this.target.position - this.m_LastTargetPosition).x;
			if (Mathf.Abs(x) > this.lookAheadMoveThreshold)
			{
				this.m_LookAheadPos = this.lookAheadFactor * Vector3.right * Mathf.Sign(x);
			}
			else
			{
				this.m_LookAheadPos = Vector3.MoveTowards(this.m_LookAheadPos, Vector3.zero, Time.deltaTime * this.lookAheadReturnSpeed);
			}
			Vector3 vector = this.target.position + this.m_LookAheadPos + Vector3.forward * this.m_OffsetZ;
			Vector3 position = Vector3.SmoothDamp(base.transform.position, vector, ref this.m_CurrentVelocity, this.damping);
			base.transform.position = position;
			this.m_LastTargetPosition = this.target.position;
		}
	}
}
