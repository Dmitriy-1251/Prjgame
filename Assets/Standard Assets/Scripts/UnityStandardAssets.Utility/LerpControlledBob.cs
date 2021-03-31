// Decompile from assembly: Assembly-CSharp-firstpass.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	[Serializable]
	public class LerpControlledBob
	{
		private sealed class _DoBobCycle_d__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int __1__state;

			private object __2__current;

			public LerpControlledBob __4__this;

			private float _t_5__2;

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

			public _DoBobCycle_d__4(int __1__state)
			{
				this.__1__state = __1__state;
			}

			void IDisposable.Dispose()
			{
			}

			bool IEnumerator.MoveNext()
			{
				int num = this.__1__state;
				LerpControlledBob lerpControlledBob = this.__4__this;
				switch (num)
				{
				case 0:
					this.__1__state = -1;
					this._t_5__2 = 0f;
					break;
				case 1:
					this.__1__state = -1;
					break;
				case 2:
					this.__1__state = -1;
					goto IL_F1;
				default:
					return false;
				}
				if (this._t_5__2 < lerpControlledBob.BobDuration)
				{
					lerpControlledBob.m_Offset = Mathf.Lerp(0f, lerpControlledBob.BobAmount, this._t_5__2 / lerpControlledBob.BobDuration);
					this._t_5__2 += Time.deltaTime;
					this.__2__current = new WaitForFixedUpdate();
					this.__1__state = 1;
					return true;
				}
				this._t_5__2 = 0f;
				IL_F1:
				if (this._t_5__2 >= lerpControlledBob.BobDuration)
				{
					lerpControlledBob.m_Offset = 0f;
					return false;
				}
				lerpControlledBob.m_Offset = Mathf.Lerp(lerpControlledBob.BobAmount, 0f, this._t_5__2 / lerpControlledBob.BobDuration);
				this._t_5__2 += Time.deltaTime;
				this.__2__current = new WaitForFixedUpdate();
				this.__1__state = 2;
				return true;
			}

			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}

		public float BobDuration;

		public float BobAmount;

		private float m_Offset;

		public float Offset()
		{
			return this.m_Offset;
		}

		[IteratorStateMachine(typeof(LerpControlledBob.<DoBobCycle>d__4))]
		public IEnumerator DoBobCycle()
		{
			LerpControlledBob._DoBobCycle_d__4 expr_06 = new LerpControlledBob._DoBobCycle_d__4(0);
			expr_06.__4__this = this;
			return expr_06;
		}
	}
}
