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
	public class FOVKick
	{
		private sealed class _FOVKickUp_d__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int __1__state;

			private object __2__current;

			public FOVKick __4__this;

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

			public _FOVKickUp_d__9(int __1__state)
			{
				this.__1__state = __1__state;
			}

			void IDisposable.Dispose()
			{
			}

			bool IEnumerator.MoveNext()
			{
				int num = this.__1__state;
				FOVKick fOVKick = this.__4__this;
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
					this._t_5__2 = Mathf.Abs((fOVKick.Camera.fieldOfView - fOVKick.originalFov) / fOVKick.FOVIncrease);
				}
				if (this._t_5__2 >= fOVKick.TimeToIncrease)
				{
					return false;
				}
				fOVKick.Camera.fieldOfView = fOVKick.originalFov + fOVKick.IncreaseCurve.Evaluate(this._t_5__2 / fOVKick.TimeToIncrease) * fOVKick.FOVIncrease;
				this._t_5__2 += Time.deltaTime;
				this.__2__current = new WaitForEndOfFrame();
				this.__1__state = 1;
				return true;
			}

			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}

		private sealed class _FOVKickDown_d__10 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int __1__state;

			private object __2__current;

			public FOVKick __4__this;

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

			public _FOVKickDown_d__10(int __1__state)
			{
				this.__1__state = __1__state;
			}

			void IDisposable.Dispose()
			{
			}

			bool IEnumerator.MoveNext()
			{
				int num = this.__1__state;
				FOVKick fOVKick = this.__4__this;
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
					this._t_5__2 = Mathf.Abs((fOVKick.Camera.fieldOfView - fOVKick.originalFov) / fOVKick.FOVIncrease);
				}
				if (this._t_5__2 <= 0f)
				{
					fOVKick.Camera.fieldOfView = fOVKick.originalFov;
					return false;
				}
				fOVKick.Camera.fieldOfView = fOVKick.originalFov + fOVKick.IncreaseCurve.Evaluate(this._t_5__2 / fOVKick.TimeToDecrease) * fOVKick.FOVIncrease;
				this._t_5__2 -= Time.deltaTime;
				this.__2__current = new WaitForEndOfFrame();
				this.__1__state = 1;
				return true;
			}

			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}

		public Camera Camera;

		[HideInInspector]
		public float originalFov;

		public float FOVIncrease = 3f;

		public float TimeToIncrease = 1f;

		public float TimeToDecrease = 1f;

		public AnimationCurve IncreaseCurve;

		public void Setup(Camera camera)
		{
			this.CheckStatus(camera);
			this.Camera = camera;
			this.originalFov = camera.fieldOfView;
		}

		private void CheckStatus(Camera camera)
		{
			if (camera == null)
			{
				throw new Exception("FOVKick camera is null, please supply the camera to the constructor");
			}
			if (this.IncreaseCurve == null)
			{
				throw new Exception("FOVKick Increase curve is null, please define the curve for the field of view kicks");
			}
		}

		public void ChangeCamera(Camera camera)
		{
			this.Camera = camera;
		}

		[IteratorStateMachine(typeof(FOVKick.<FOVKickUp>d__9))]
		public IEnumerator FOVKickUp()
		{
			FOVKick._FOVKickUp_d__9 expr_06 = new FOVKick._FOVKickUp_d__9(0);
			expr_06.__4__this = this;
			return expr_06;
		}

		[IteratorStateMachine(typeof(FOVKick.<FOVKickDown>d__10))]
		public IEnumerator FOVKickDown()
		{
			FOVKick._FOVKickDown_d__10 expr_06 = new FOVKick._FOVKickDown_d__10(0);
			expr_06.__4__this = this;
			return expr_06;
		}
	}
}
