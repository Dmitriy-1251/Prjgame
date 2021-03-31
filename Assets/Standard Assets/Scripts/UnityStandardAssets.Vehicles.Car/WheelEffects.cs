// Decompile from assembly: Assembly-CSharp-firstpass.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	[RequireComponent(typeof(AudioSource))]
	public class WheelEffects : MonoBehaviour
	{
		private sealed class _StartSkidTrail_d__18 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int __1__state;

			private object __2__current;

			public WheelEffects __4__this;

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

			public _StartSkidTrail_d__18(int __1__state)
			{
				this.__1__state = __1__state;
			}

			void IDisposable.Dispose()
			{
			}

			bool IEnumerator.MoveNext()
			{
				int num = this.__1__state;
				WheelEffects wheelEffects = this.__4__this;
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
					wheelEffects.skidding = true;
					wheelEffects.m_SkidTrail = UnityEngine.Object.Instantiate<Transform>(wheelEffects.SkidTrailPrefab);
				}
				if (!(wheelEffects.m_SkidTrail == null))
				{
					wheelEffects.m_SkidTrail.parent = wheelEffects.transform;
					wheelEffects.m_SkidTrail.localPosition = -Vector3.up * wheelEffects.m_WheelCollider.radius;
					return false;
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

		public Transform SkidTrailPrefab;

		public static Transform skidTrailsDetachedParent;

		public ParticleSystem skidParticles;

		private AudioSource m_AudioSource;

		private Transform m_SkidTrail;

		private WheelCollider m_WheelCollider;

		public bool skidding
		{
			get;
			private set;
		}

		public bool PlayingAudio
		{
			get;
			private set;
		}

		private void Start()
		{
			this.skidParticles = base.transform.root.GetComponentInChildren<ParticleSystem>();
			if (this.skidParticles == null)
			{
				UnityEngine.Debug.LogWarning(" no particle system found on car to generate smoke particles", base.gameObject);
			}
			else
			{
				this.skidParticles.Stop();
			}
			this.m_WheelCollider = base.GetComponent<WheelCollider>();
			this.m_AudioSource = base.GetComponent<AudioSource>();
			this.PlayingAudio = false;
			if (WheelEffects.skidTrailsDetachedParent == null)
			{
				WheelEffects.skidTrailsDetachedParent = new GameObject("Skid Trails - Detached").transform;
			}
		}

		public void EmitTyreSmoke()
		{
			this.skidParticles.transform.position = base.transform.position - base.transform.up * this.m_WheelCollider.radius;
			this.skidParticles.Emit(1);
			if (!this.skidding)
			{
				base.StartCoroutine(this.StartSkidTrail());
			}
		}

		public void PlayAudio()
		{
			this.m_AudioSource.Play();
			this.PlayingAudio = true;
		}

		public void StopAudio()
		{
			this.m_AudioSource.Stop();
			this.PlayingAudio = false;
		}

		[IteratorStateMachine(typeof(WheelEffects.<StartSkidTrail>d__18))]
		public IEnumerator StartSkidTrail()
		{
			WheelEffects._StartSkidTrail_d__18 expr_06 = new WheelEffects._StartSkidTrail_d__18(0);
			expr_06.__4__this = this;
			return expr_06;
		}

		public void EndSkidTrail()
		{
			if (!this.skidding)
			{
				return;
			}
			this.skidding = false;
			this.m_SkidTrail.parent = WheelEffects.skidTrailsDetachedParent;
			UnityEngine.Object.Destroy(this.m_SkidTrail.gameObject, 10f);
		}
	}
}
