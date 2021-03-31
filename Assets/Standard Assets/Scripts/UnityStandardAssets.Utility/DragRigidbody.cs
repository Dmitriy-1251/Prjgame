// Decompile from assembly: Assembly-CSharp-firstpass.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	public class DragRigidbody : MonoBehaviour
	{
		private sealed class _DragObject_d__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int __1__state;

			private object __2__current;

			public DragRigidbody __4__this;

			public float distance;

			private float _oldDrag_5__2;

			private float _oldAngularDrag_5__3;

			private Camera _mainCamera_5__4;

			object IEnumerator<object>.Current
			{
				get
				{
					return this.__2__current;
				}
			}

			object IEnumerator.Current
			{
				get
				{
					return this.__2__current;
				}
			}

			public _DragObject_d__8(int __1__state)
			{
				this.__1__state = __1__state;
			}

			void IDisposable.Dispose()
			{
			}

			bool IEnumerator.MoveNext()
			{
				int num = this.__1__state;
				DragRigidbody dragRigidbody = this.__4__this;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					this.__1__state = -1;
				}
				else
				{
					this.__1__state = -1;
					this._oldDrag_5__2 = dragRigidbody.m_SpringJoint.connectedBody.drag;
					this._oldAngularDrag_5__3 = dragRigidbody.m_SpringJoint.connectedBody.angularDrag;
					dragRigidbody.m_SpringJoint.connectedBody.drag = 10f;
					dragRigidbody.m_SpringJoint.connectedBody.angularDrag = 5f;
					this._mainCamera_5__4 = dragRigidbody.FindCamera();
				}
				if (!Input.GetMouseButton(0))
				{
					if (dragRigidbody.m_SpringJoint.connectedBody)
					{
						dragRigidbody.m_SpringJoint.connectedBody.drag = this._oldDrag_5__2;
						dragRigidbody.m_SpringJoint.connectedBody.angularDrag = this._oldAngularDrag_5__3;
						dragRigidbody.m_SpringJoint.connectedBody = null;
					}
					return false;
				}
				Ray ray = this._mainCamera_5__4.ScreenPointToRay(Input.mousePosition);
				dragRigidbody.m_SpringJoint.transform.position = ray.GetPoint(this.distance);
				this.__2__current = null;
				this.__1__state = 1;
				return true;
			}

			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}

		private const float k_Spring = 50f;

		private const float k_Damper = 5f;

		private const float k_Drag = 10f;

		private const float k_AngularDrag = 5f;

		private const float k_Distance = 0.2f;

		private const bool k_AttachToCenterOfMass = false;

		private SpringJoint m_SpringJoint;

		private void Update()
		{
			if (!Input.GetMouseButtonDown(0))
			{
				return;
			}
			Camera camera = this.FindCamera();
			RaycastHit raycastHit = default(RaycastHit);
			if (!Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition).origin, camera.ScreenPointToRay(Input.mousePosition).direction, out raycastHit, 100f, -5))
			{
				return;
			}
			if (!raycastHit.rigidbody || raycastHit.rigidbody.isKinematic)
			{
				return;
			}
			if (!this.m_SpringJoint)
			{
				GameObject gameObject = new GameObject("Rigidbody dragger");
				Rigidbody arg_97_0 = gameObject.AddComponent<Rigidbody>();
				this.m_SpringJoint = gameObject.AddComponent<SpringJoint>();
				arg_97_0.isKinematic = true;
			}
			this.m_SpringJoint.transform.position = raycastHit.point;
			this.m_SpringJoint.anchor = Vector3.zero;
			this.m_SpringJoint.spring = 50f;
			this.m_SpringJoint.damper = 5f;
			this.m_SpringJoint.maxDistance = 0.2f;
			this.m_SpringJoint.connectedBody = raycastHit.rigidbody;
			base.StartCoroutine("DragObject", raycastHit.distance);
		}

		[IteratorStateMachine(typeof(DragRigidbody.<DragObject>d__8))]
		private IEnumerator DragObject(float distance)
		{
			DragRigidbody._DragObject_d__8 expr_06 = new DragRigidbody._DragObject_d__8(0);
			expr_06.__4__this = this;
			expr_06.distance = distance;
			return expr_06;
		}

		private Camera FindCamera()
		{
			if (base.GetComponent<Camera>())
			{
				return base.GetComponent<Camera>();
			}
			return Camera.main;
		}
	}
}
