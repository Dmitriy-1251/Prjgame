// Decompile from assembly: Assembly-CSharp-firstpass.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	public class ObjectResetter : MonoBehaviour
	{
		private sealed class _ResetCoroutine_d__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int __1__state;

			private object __2__current;

			public float delay;

			public ObjectResetter __4__this;

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

			public _ResetCoroutine_d__6(int __1__state)
			{
				this.__1__state = __1__state;
			}

			void IDisposable.Dispose()
			{
			}

			bool IEnumerator.MoveNext()
			{
				int num = this.__1__state;
				ObjectResetter objectResetter = this.__4__this;
				if (num == 0)
				{
					this.__1__state = -1;
					this.__2__current = new WaitForSeconds(this.delay);
					this.__1__state = 1;
					return true;
				}
				if (num != 1)
				{
					return false;
				}
				this.__1__state = -1;
				Transform[] componentsInChildren = objectResetter.GetComponentsInChildren<Transform>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					Transform transform = componentsInChildren[i];
					if (!objectResetter.originalStructure.Contains(transform))
					{
						transform.parent = null;
					}
				}
				objectResetter.transform.position = objectResetter.originalPosition;
				objectResetter.transform.rotation = objectResetter.originalRotation;
				if (objectResetter.Rigidbody)
				{
					objectResetter.Rigidbody.velocity = Vector3.zero;
					objectResetter.Rigidbody.angularVelocity = Vector3.zero;
				}
				objectResetter.SendMessage("Reset");
				return false;
			}

			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}

		private Vector3 originalPosition;

		private Quaternion originalRotation;

		private List<Transform> originalStructure;

		private Rigidbody Rigidbody;

		private void Start()
		{
			this.originalStructure = new List<Transform>(base.GetComponentsInChildren<Transform>());
			this.originalPosition = base.transform.position;
			this.originalRotation = base.transform.rotation;
			this.Rigidbody = base.GetComponent<Rigidbody>();
		}

		public void DelayedReset(float delay)
		{
			base.StartCoroutine(this.ResetCoroutine(delay));
		}

		[IteratorStateMachine(typeof(ObjectResetter.<ResetCoroutine>d__6))]
		public IEnumerator ResetCoroutine(float delay)
		{
			ObjectResetter._ResetCoroutine_d__6 expr_06 = new ObjectResetter._ResetCoroutine_d__6(0);
			expr_06.__4__this = this;
			expr_06.delay = delay;
			return expr_06;
		}
	}
}
