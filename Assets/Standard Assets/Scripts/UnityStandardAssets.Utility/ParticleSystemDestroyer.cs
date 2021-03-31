// Decompile from assembly: Assembly-CSharp-firstpass.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	public class ParticleSystemDestroyer : MonoBehaviour
	{
		private sealed class _Start_d__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int __1__state;

			private object __2__current;

			public ParticleSystemDestroyer __4__this;

			private ParticleSystem[] _systems_5__2;

			private float _stopTime_5__3;

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

			public _Start_d__4(int __1__state)
			{
				this.__1__state = __1__state;
			}

			void IDisposable.Dispose()
			{
			}

			bool IEnumerator.MoveNext()
			{
				int num = this.__1__state;
				ParticleSystemDestroyer particleSystemDestroyer = this.__4__this;
				switch (num)
				{
				case 0:
				{
					this.__1__state = -1;
					this._systems_5__2 = particleSystemDestroyer.GetComponentsInChildren<ParticleSystem>();
					ParticleSystem[] array = this._systems_5__2;
					for (int i = 0; i < array.Length; i++)
					{
						ParticleSystem particleSystem = array[i];
						particleSystemDestroyer.m_MaxLifetime = Mathf.Max(particleSystem.main.startLifetime.constant, particleSystemDestroyer.m_MaxLifetime);
					}
					this._stopTime_5__3 = Time.time + UnityEngine.Random.Range(particleSystemDestroyer.minDuration, particleSystemDestroyer.maxDuration);
					break;
				}
				case 1:
					this.__1__state = -1;
					break;
				case 2:
					this.__1__state = -1;
					UnityEngine.Object.Destroy(particleSystemDestroyer.gameObject);
					return false;
				default:
					return false;
				}
				if (Time.time >= this._stopTime_5__3 || particleSystemDestroyer.m_EarlyStop)
				{
					UnityEngine.Debug.Log("stopping " + particleSystemDestroyer.name);
					ParticleSystem[] array = this._systems_5__2;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].emission.enabled = false;
					}
					particleSystemDestroyer.BroadcastMessage("Extinguish", SendMessageOptions.DontRequireReceiver);
					this.__2__current = new WaitForSeconds(particleSystemDestroyer.m_MaxLifetime);
					this.__1__state = 2;
					return true;
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

		public float minDuration = 8f;

		public float maxDuration = 10f;

		private float m_MaxLifetime;

		private bool m_EarlyStop;

		[IteratorStateMachine(typeof(ParticleSystemDestroyer.<Start>d__4))]
		private IEnumerator Start()
		{
			ParticleSystemDestroyer._Start_d__4 expr_06 = new ParticleSystemDestroyer._Start_d__4(0);
			expr_06.__4__this = this;
			return expr_06;
		}

		public void Stop()
		{
			this.m_EarlyStop = true;
		}
	}
}
