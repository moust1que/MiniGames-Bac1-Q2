using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemFall : MonoBehaviour {
	private GameObject m_Fire;
	private Vector3 m_SpeedCoef = new Vector3(0.0f, 0.1f, 0.0f);
	private float m_Speed = 0.0f;

	public void StartFall() {
		m_Speed = -2.0f;
	}

	public void StopFall() {
		m_Speed = 0.0f;
	}

	private void FixedUpdate() {
		transform.position = transform.position + Screen.height * m_SpeedCoef * m_Speed * Time.fixedDeltaTime;
	}
}