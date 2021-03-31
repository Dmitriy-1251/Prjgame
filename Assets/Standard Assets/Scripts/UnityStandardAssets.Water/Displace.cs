// Decompile from assembly: Assembly-CSharp-firstpass.dll

using System;
using UnityEngine;

namespace UnityStandardAssets.Water
{
	[ExecuteInEditMode, RequireComponent(typeof(WaterBase))]
	public class Displace : MonoBehaviour
	{
		public void Awake()
		{
			if (base.enabled)
			{
				this.OnEnable();
				return;
			}
			this.OnDisable();
		}

		public void OnEnable()
		{
			Shader.EnableKeyword("WATER_VERTEX_DISPLACEMENT_ON");
			Shader.DisableKeyword("WATER_VERTEX_DISPLACEMENT_OFF");
		}

		public void OnDisable()
		{
			Shader.EnableKeyword("WATER_VERTEX_DISPLACEMENT_OFF");
			Shader.DisableKeyword("WATER_VERTEX_DISPLACEMENT_ON");
		}
	}
}
