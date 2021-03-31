// Decompile from assembly: Assembly-CSharp-firstpass.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace UnityStandardAssets.Effects
{
	public class ExplosionFireAndDebris : MonoBehaviour
	{
		private sealed class _Start_d__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int __1__state;

			private object __2__current;

			public ExplosionFireAndDebris __4__this;

			private float _multiplier_5__2;

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
				ExplosionFireAndDebris explosionFireAndDebris = this.__4__this;
				if (num == 0)
				{
					this.__1__state = -1;
					this._multiplier_5__2 = explosionFireAndDebris.GetComponent<ParticleSystemMultiplier>().multiplier;
					int num2 = 0;
					while ((float)num2 < (float)explosionFireAndDebris.numDebrisPieces * this._multiplier_5__2)
					{
						Transform arg_83_0 = explosionFireAndDebris.debrisPrefabs[UnityEngine.Random.Range(0, explosionFireAndDebris.debrisPrefabs.Length)];
						Vector3 position = explosionFireAndDebris.transform.position + UnityEngine.Random.insideUnitSphere * 3f * this._multiplier_5__2;
						Quaternion rotation = UnityEngine.Random.rotation;
						UnityEngine.Object.Instantiate<Transform>(arg_83_0, position, rotation);
						num2++;
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
				float num3 = 10f * this._multiplier_5__2;
				Collider[] array = Physics.OverlapSphere(explosionFireAndDebris.transform.position, num3);
				for (int i = 0; i < array.Length; i++)
				{
					Collider collider = array[i];
					if (explosionFireAndDebris.numFires > 0)
					{
						Ray ray = new Ray(explosionFireAndDebris.transform.position, collider.transform.position - explosionFireAndDebris.transform.position);
						RaycastHit raycastHit;
						if (collider.Raycast(ray, out raycastHit, num3))
						{
							explosionFireAndDebris.AddFire(collider.transform, raycastHit.point, raycastHit.normal);
							explosionFireAndDebris.numFires--;
						}
					}
				}
				float num4 = 0f;
				while (explosionFireAndDebris.numFires > 0 && num4 < num3)
				{
					RaycastHit raycastHit2;
					if (Physics.Raycast(new Ray(explosionFireAndDebris.transform.position + Vector3.up, UnityEngine.Random.onUnitSphere), out raycastHit2, num4))
					{
						explosionFireAndDebris.AddFire(null, raycastHit2.point, raycastHit2.normal);
						explosionFireAndDebris.numFires--;
					}
					num4 += num3 * 0.1f;
				}
				return false;
			}

			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}

		public Transform[] debrisPrefabs;

		public Transform firePrefab;

		public int numDebrisPieces;

		public int numFires;

		[IteratorStateMachine(typeof(ExplosionFireAndDebris.<Start>d__4))]
		private IEnumerator Start()
		{
			ExplosionFireAndDebris._Start_d__4 expr_06 = new ExplosionFireAndDebris._Start_d__4(0);
			expr_06.__4__this = this;
			return expr_06;
		}

		private void AddFire(Transform t, Vector3 pos, Vector3 normal)
		{
			pos += normal * 0.5f;
			UnityEngine.Object.Instantiate<Transform>(this.firePrefab, pos, Quaternion.identity).parent = t;
		}
	}
}
