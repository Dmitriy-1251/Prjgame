// Decompile from assembly: Assembly-CSharp-firstpass.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Utility
{
	public class TimedObjectActivator : MonoBehaviour
	{
		public enum Action
		{
			Activate,
			Deactivate,
			Destroy,
			ReloadLevel,
			Call
		}

		[Serializable]
		public class Entry
		{
			public GameObject target;

			public TimedObjectActivator.Action action;

			public float delay;
		}

		[Serializable]
		public class Entries
		{
			public TimedObjectActivator.Entry[] entries;
		}

		private sealed class _Activate_d__5 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int __1__state;

			private object __2__current;

			public TimedObjectActivator.Entry entry;

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

			public _Activate_d__5(int __1__state)
			{
				this.__1__state = __1__state;
			}

			void IDisposable.Dispose()
			{
			}

			bool IEnumerator.MoveNext()
			{
				int num = this.__1__state;
				if (num == 0)
				{
					this.__1__state = -1;
					this.__2__current = new WaitForSeconds(this.entry.delay);
					this.__1__state = 1;
					return true;
				}
				if (num != 1)
				{
					return false;
				}
				this.__1__state = -1;
				this.entry.target.SetActive(true);
				return false;
			}

			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}

		private sealed class _Deactivate_d__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int __1__state;

			private object __2__current;

			public TimedObjectActivator.Entry entry;

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

			public _Deactivate_d__6(int __1__state)
			{
				this.__1__state = __1__state;
			}

			void IDisposable.Dispose()
			{
			}

			bool IEnumerator.MoveNext()
			{
				int num = this.__1__state;
				if (num == 0)
				{
					this.__1__state = -1;
					this.__2__current = new WaitForSeconds(this.entry.delay);
					this.__1__state = 1;
					return true;
				}
				if (num != 1)
				{
					return false;
				}
				this.__1__state = -1;
				this.entry.target.SetActive(false);
				return false;
			}

			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}

		private sealed class _ReloadLevel_d__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int __1__state;

			private object __2__current;

			public TimedObjectActivator.Entry entry;

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

			public _ReloadLevel_d__7(int __1__state)
			{
				this.__1__state = __1__state;
			}

			void IDisposable.Dispose()
			{
			}

			bool IEnumerator.MoveNext()
			{
				int num = this.__1__state;
				if (num == 0)
				{
					this.__1__state = -1;
					this.__2__current = new WaitForSeconds(this.entry.delay);
					this.__1__state = 1;
					return true;
				}
				if (num != 1)
				{
					return false;
				}
				this.__1__state = -1;
				SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
				return false;
			}

			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}

		public TimedObjectActivator.Entries entries = new TimedObjectActivator.Entries();

		private void Awake()
		{
			TimedObjectActivator.Entry[] array = this.entries.entries;
			for (int i = 0; i < array.Length; i++)
			{
				TimedObjectActivator.Entry entry = array[i];
				switch (entry.action)
				{
				case TimedObjectActivator.Action.Activate:
					base.StartCoroutine(this.Activate(entry));
					break;
				case TimedObjectActivator.Action.Deactivate:
					base.StartCoroutine(this.Deactivate(entry));
					break;
				case TimedObjectActivator.Action.Destroy:
					UnityEngine.Object.Destroy(entry.target, entry.delay);
					break;
				case TimedObjectActivator.Action.ReloadLevel:
					base.StartCoroutine(this.ReloadLevel(entry));
					break;
				}
			}
		}

		[IteratorStateMachine(typeof(TimedObjectActivator.<Activate>d__5))]
		private IEnumerator Activate(TimedObjectActivator.Entry entry)
		{
			TimedObjectActivator._Activate_d__5 expr_06 = new TimedObjectActivator._Activate_d__5(0);
			expr_06.entry = entry;
			return expr_06;
		}

		[IteratorStateMachine(typeof(TimedObjectActivator.<Deactivate>d__6))]
		private IEnumerator Deactivate(TimedObjectActivator.Entry entry)
		{
			TimedObjectActivator._Deactivate_d__6 expr_06 = new TimedObjectActivator._Deactivate_d__6(0);
			expr_06.entry = entry;
			return expr_06;
		}

		[IteratorStateMachine(typeof(TimedObjectActivator.<ReloadLevel>d__7))]
		private IEnumerator ReloadLevel(TimedObjectActivator.Entry entry)
		{
			TimedObjectActivator._ReloadLevel_d__7 expr_06 = new TimedObjectActivator._ReloadLevel_d__7(0);
			expr_06.entry = entry;
			return expr_06;
		}
	}
}
