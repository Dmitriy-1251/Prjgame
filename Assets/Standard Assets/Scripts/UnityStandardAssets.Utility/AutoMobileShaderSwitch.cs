// Decompile from assembly: Assembly-CSharp-firstpass.dll

using System;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	public class AutoMobileShaderSwitch : MonoBehaviour
	{
		[Serializable]
		public class ReplacementDefinition
		{
			public Shader original;

			public Shader replacement;
		}

		[Serializable]
		public class ReplacementList
		{
			public AutoMobileShaderSwitch.ReplacementDefinition[] items = new AutoMobileShaderSwitch.ReplacementDefinition[0];
		}

		[SerializeField]
		private AutoMobileShaderSwitch.ReplacementList m_ReplacementList;

		private void OnEnable()
		{
		}
	}
}
