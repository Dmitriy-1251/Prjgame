// Decompile from assembly: Assembly-CSharp-firstpass.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace UnityStandardAssets.Effects
{
	public class ExplosionPhysicsForce : MonoBehaviour
	{
		private sealed class _Start_d__1 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int __1__state;

			private object __2__current;

			public ExplosionPhysicsForce __4__this;

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

			public _Start_d__1(int __1__state)
			{
				this.__1__state = __1__state;
			}

			void IDisposable.Dispose()
			{
			}

			bool IEnumerator.MoveNext()
			{
				int num = this.__1__state;
				ExplosionPhysicsForce explosionPhysicsForce = this.__4__this;
				if (num == 0)
				{
					this.__1__state = -1;
					this.__2__current = null;
					this.__1__state = 1;
					return true;
				}
				if (num != 1)
				{
					return false;
				}
				this.__1__state = -1;
				float multiplier = explosionPhysicsForce.GetComponent<ParticleSystemMultiplier>().multiplier;
				float num2 = 10f * multiplier;
				Collider[] arg_61_0 = Physics.OverlapSphere(explosionPhysicsForce.transform.position, num2);
				List<Rigidbody> list = new List<Rigidbody>();
				Collider[] array = arg_61_0;
				for (int i = 0; i < array.Length; i++)
				{
					Collider collider = array[i];
					if (collider.attachedRigidbody != null && !list.Contains(collider.attachedRigidbody))
					{
						list.Add(collider.attachedRigidbody);
					}
				}
				using (List<Rigidbody>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						enumerator.Current.AddExplosionForce(explosionPhysicsForce.explosionForce * multiplier, explosionPhysicsForce.transform.position, num2, 1f * multiplier, ForceMode.Impulse);
					}
				}
				return false;
			}

			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}

		public float explosionForce = 4f;

		[IteratorStateMachine(typeof(ExplosionPhysicsForce.<Start>d__1))]
		private IEnumerator Start()
		{
			ExplosionPhysicsForce._Start_d__1 expr_06 = new ExplosionPhysicsForce._Start_d__1(0);
			expr_06.__4__this = this;
			return expr_06;
		}
	}
}
