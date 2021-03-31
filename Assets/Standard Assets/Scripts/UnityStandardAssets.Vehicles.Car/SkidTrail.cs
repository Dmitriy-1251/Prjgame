// Decompile from assembly: Assembly-CSharp-firstpass.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	public class SkidTrail : MonoBehaviour
	{
		private sealed class _Start_d__1 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int __1__state;

			private object __2__current;

			public SkidTrail __4__this;

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
				SkidTrail skidTrail = this.__4__this;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					this.__1__state = -1;
					if (skidTrail.transform.parent.parent == null)
					{
						UnityEngine.Object.Destroy(skidTrail.gameObject, skidTrail.m_PersistTime);
					}
				}
				else
				{
					this.__1__state = -1;
				}
				this.__2__current = null;
				this.__1__state = 1;
				return true;
			}

			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}

		[SerializeField]
		private float m_PersistTime;

		[IteratorStateMachine(typeof(SkidTrail.<Start>d__1))]
		private IEnumerator Start()
		{
			SkidTrail._Start_d__1 expr_06 = new SkidTrail._Start_d__1(0);
			expr_06.__4__this = this;
			return expr_06;
		}
	}
}
