// Decompile from assembly: Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.SceneUtils
{
	public class SlowMoButton : MonoBehaviour
	{
		public Sprite FullSpeedTex;

		public Sprite SlowSpeedTex;

		public float fullSpeed = 1f;

		public float slowSpeed = 0.3f;

		public Button button;

		private bool m_SlowMo;

		private void Start()
		{
			this.m_SlowMo = false;
		}

		private void OnDestroy()
		{
			Time.timeScale = 1f;
		}

		public void ChangeSpeed()
		{
			this.m_SlowMo = !this.m_SlowMo;
			Image image = this.button.targetGraphic as Image;
			if (image != null)
			{
				image.sprite = (this.m_SlowMo ? this.SlowSpeedTex : this.FullSpeedTex);
			}
			this.button.targetGraphic = image;
			Time.timeScale = (this.m_SlowMo ? this.slowSpeed : this.fullSpeed);
		}
	}
}
