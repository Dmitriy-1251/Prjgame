// Decompile from assembly: Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityStandardAssets.Effects;

namespace UnityStandardAssets.SceneUtils
{
	public class ParticleSceneControls : MonoBehaviour
	{
		public enum Mode
		{
			Activate,
			Instantiate,
			Trail
		}

		public enum AlignMode
		{
			Normal,
			Up
		}

		[Serializable]
		public class DemoParticleSystem
		{
			public Transform transform;

			public ParticleSceneControls.Mode mode;

			public ParticleSceneControls.AlignMode align;

			public int maxCount;

			public float minDist;

			public int camOffset = 15;

			public string instructionText;
		}

		[Serializable]
		public class DemoParticleSystemList
		{
			public ParticleSceneControls.DemoParticleSystem[] items;
		}

		public ParticleSceneControls.DemoParticleSystemList demoParticles;

		public float spawnOffset = 0.5f;

		public float multiply = 1f;

		public bool clearOnChange;

		public Text titleText;

		public Transform sceneCamera;

		public Text instructionText;

		public Button previousButton;

		public Button nextButton;

		public GraphicRaycaster graphicRaycaster;

		public EventSystem eventSystem;

		private ParticleSystemMultiplier m_ParticleMultiplier;

		private List<Transform> m_CurrentParticleList = new List<Transform>();

		private Transform m_Instance;

		private static int s_SelectedIndex;

		private Vector3 m_CamOffsetVelocity = Vector3.zero;

		private Vector3 m_LastPos;

		private static ParticleSceneControls.DemoParticleSystem s_Selected;

		private void Awake()
		{
			this.Select(ParticleSceneControls.s_SelectedIndex);
			this.previousButton.onClick.AddListener(new UnityAction(this.Previous));
			this.nextButton.onClick.AddListener(new UnityAction(this.Next));
		}

		private void OnDisable()
		{
			this.previousButton.onClick.RemoveListener(new UnityAction(this.Previous));
			this.nextButton.onClick.RemoveListener(new UnityAction(this.Next));
		}

		private void Previous()
		{
			ParticleSceneControls.s_SelectedIndex--;
			if (ParticleSceneControls.s_SelectedIndex == -1)
			{
				ParticleSceneControls.s_SelectedIndex = this.demoParticles.items.Length - 1;
			}
			this.Select(ParticleSceneControls.s_SelectedIndex);
		}

		public void Next()
		{
			ParticleSceneControls.s_SelectedIndex++;
			if (ParticleSceneControls.s_SelectedIndex == this.demoParticles.items.Length)
			{
				ParticleSceneControls.s_SelectedIndex = 0;
			}
			this.Select(ParticleSceneControls.s_SelectedIndex);
		}

		private void Update()
		{
			this.KeyboardInput();
			this.sceneCamera.localPosition = Vector3.SmoothDamp(this.sceneCamera.localPosition, Vector3.forward * (float)(-(float)ParticleSceneControls.s_Selected.camOffset), ref this.m_CamOffsetVelocity, 1f);
			if (ParticleSceneControls.s_Selected.mode == ParticleSceneControls.Mode.Activate)
			{
				return;
			}
			if (this.CheckForGuiCollision())
			{
				return;
			}
			bool arg_8A_0 = Input.GetMouseButtonDown(0) && ParticleSceneControls.s_Selected.mode == ParticleSceneControls.Mode.Instantiate;
			bool flag = Input.GetMouseButton(0) && ParticleSceneControls.s_Selected.mode == ParticleSceneControls.Mode.Trail;
			RaycastHit raycastHit;
			if ((arg_8A_0 | flag) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit))
			{
				Quaternion rotation = Quaternion.LookRotation(raycastHit.normal);
				if (ParticleSceneControls.s_Selected.align == ParticleSceneControls.AlignMode.Up)
				{
					rotation = Quaternion.identity;
				}
				Vector3 vector = raycastHit.point + raycastHit.normal * this.spawnOffset;
				if ((vector - this.m_LastPos).magnitude > ParticleSceneControls.s_Selected.minDist)
				{
					if (ParticleSceneControls.s_Selected.mode != ParticleSceneControls.Mode.Trail || this.m_Instance == null)
					{
						this.m_Instance = UnityEngine.Object.Instantiate<Transform>(ParticleSceneControls.s_Selected.transform, vector, rotation);
						if (this.m_ParticleMultiplier != null)
						{
							this.m_Instance.GetComponent<ParticleSystemMultiplier>().multiplier = this.multiply;
						}
						this.m_CurrentParticleList.Add(this.m_Instance);
						if (ParticleSceneControls.s_Selected.maxCount > 0 && this.m_CurrentParticleList.Count > ParticleSceneControls.s_Selected.maxCount)
						{
							if (this.m_CurrentParticleList[0] != null)
							{
								UnityEngine.Object.Destroy(this.m_CurrentParticleList[0].gameObject);
							}
							this.m_CurrentParticleList.RemoveAt(0);
						}
					}
					else
					{
						this.m_Instance.position = vector;
						this.m_Instance.rotation = rotation;
					}
					if (ParticleSceneControls.s_Selected.mode == ParticleSceneControls.Mode.Trail)
					{
						this.m_Instance.transform.GetComponent<ParticleSystem>().emission.enabled = false;
						this.m_Instance.transform.GetComponent<ParticleSystem>().Emit(1);
					}
					this.m_Instance.parent = raycastHit.transform;
					this.m_LastPos = vector;
				}
			}
		}

		private void KeyboardInput()
		{
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				this.Previous();
			}
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				this.Next();
			}
		}

		private bool CheckForGuiCollision()
		{
			PointerEventData pointerEventData = new PointerEventData(this.eventSystem);
			pointerEventData.pressPosition = Input.mousePosition;
			pointerEventData.position = Input.mousePosition;
			List<RaycastResult> list = new List<RaycastResult>();
			this.graphicRaycaster.Raycast(pointerEventData, list);
			return list.Count > 0;
		}

		private void Select(int i)
		{
			ParticleSceneControls.s_Selected = this.demoParticles.items[i];
			this.m_Instance = null;
			ParticleSceneControls.DemoParticleSystem[] items = this.demoParticles.items;
			for (int j = 0; j < items.Length; j++)
			{
				ParticleSceneControls.DemoParticleSystem demoParticleSystem = items[j];
				if (demoParticleSystem != ParticleSceneControls.s_Selected && demoParticleSystem.mode == ParticleSceneControls.Mode.Activate)
				{
					demoParticleSystem.transform.gameObject.SetActive(false);
				}
			}
			if (ParticleSceneControls.s_Selected.mode == ParticleSceneControls.Mode.Activate)
			{
				ParticleSceneControls.s_Selected.transform.gameObject.SetActive(true);
			}
			this.m_ParticleMultiplier = ParticleSceneControls.s_Selected.transform.GetComponent<ParticleSystemMultiplier>();
			this.multiply = 1f;
			if (this.clearOnChange)
			{
				while (this.m_CurrentParticleList.Count > 0)
				{
					UnityEngine.Object.Destroy(this.m_CurrentParticleList[0].gameObject);
					this.m_CurrentParticleList.RemoveAt(0);
				}
			}
			this.instructionText.text = ParticleSceneControls.s_Selected.instructionText;
			this.titleText.text = ParticleSceneControls.s_Selected.transform.name;
		}
	}
}
