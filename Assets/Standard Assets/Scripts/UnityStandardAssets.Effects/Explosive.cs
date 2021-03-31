// Decompile from assembly: Assembly-CSharp-firstpass.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityStandardAssets.Utility;

namespace UnityStandardAssets.Effects
{
	public class Explosive : MonoBehaviour
	{
		private sealed class _OnCollisionEnter_d__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int __1__state;

			private object __2__current;

			public Explosive __4__this;

			public Collision col;

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

			public _OnCollisionEnter_d__8(int __1__state)
			{
				this.__1__state = __1__state;
			}

			void IDisposable.Dispose()
			{
			}

			bool IEnumerator.MoveNext()
			{
				int num = this.__1__state;
				Explosive explosive = this.__4__this;
				if (num == 0)
				{
					this.__1__state = -1;
					if (explosive.enabled && this.col.contacts.Length != 0 && (Vector3.Project(this.col.relativeVelocity, this.col.contacts[0].normal).magnitude > explosive.detonationImpactVelocity || explosive.m_Exploded) && !explosive.m_Exploded)
					{
						UnityEngine.Object.Instantiate<Transform>(explosive.explosionPrefab, this.col.contacts[0].point, Quaternion.LookRotation(this.col.contacts[0].normal));
						explosive.m_Exploded = true;
						explosive.SendMessage("Immobilize");
						if (explosive.reset)
						{
							explosive.m_ObjectResetter.DelayedReset(explosive.resetTimeDelay);
						}
					}
					this.__2__current = null;
					this.__1__state = 1;
					return true;
				}
				if (num != 1)
				{
					return false;
				}
				this.__1__state = -1;
				return false;
			}

			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}

		public Transform explosionPrefab;

		public float detonationImpactVelocity = 10f;

		public float sizeMultiplier = 1f;

		public bool reset = true;

		public float resetTimeDelay = 10f;

		private bool m_Exploded;

		private ObjectResetter m_ObjectResetter;

		private void Start()
		{
			this.m_ObjectResetter = base.GetComponent<ObjectResetter>();
		}

		[IteratorStateMachine(typeof(Explosive.<OnCollisionEnter>d__8))]
		private IEnumerator OnCollisionEnter(Collision col)
		{
			Explosive._OnCollisionEnter_d__8 expr_06 = new Explosive._OnCollisionEnter_d__8(0);
			expr_06.__4__this = this;
			expr_06.col = col;
			return expr_06;
		}

		public void Reset()
		{
			this.m_Exploded = false;
		}
	}
}
