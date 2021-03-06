// Decompile from assembly: Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
	public GameObject[] objects;

	public Text text;

	private int m_CurrentActiveObject;

	private void OnEnable()
	{
		this.text.text = this.objects[this.m_CurrentActiveObject].name;
	}

	public void NextCamera()
	{
		int num = (this.m_CurrentActiveObject + 1 >= this.objects.Length) ? 0 : (this.m_CurrentActiveObject + 1);
		for (int i = 0; i < this.objects.Length; i++)
		{
			this.objects[i].SetActive(i == num);
		}
		this.m_CurrentActiveObject = num;
		this.text.text = this.objects[this.m_CurrentActiveObject].name;
	}
}
