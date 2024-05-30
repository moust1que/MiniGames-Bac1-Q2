using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScaleBasedOnScore : MonoBehaviour {
	[SerializeField] private GameManager m_GameManager;

	private void FixedUpdate() {
		switch(m_GameManager.m_Score) {
			case 0:
				SetScale(0.0f);
				break;
			case 10:
				SetScale(0.5f);
				break;
			case 20:
				SetScale(0.6f);
				break;
			case 30:
				SetScale(0.7f);
				break;
			case 40:
				SetScale(0.8f);
				break;
			case 50:
				SetScale(0.9f);
				break;
			case 60:
				SetScale(1.0f);
				break;
			case 70:
				SetScale(1.1f);
				break;
			case 80:
				SetScale(1.2f);
				break;
			case 90:
				SetScale(1.3f);
				break;
			case 100:
				SetScale(1.4f);
				break;
		}
	}

	private void SetScale(float scale) {
		gameObject.transform.localScale = new Vector3(scale, scale, scale);
	}
}