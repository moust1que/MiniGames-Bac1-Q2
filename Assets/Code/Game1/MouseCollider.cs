using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCollider : MonoBehaviour {
	[SerializeField] private AudioSource m_HitStone;

	private void Update() {
		Vector3 mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
		mousePosition = new Vector3(mousePosition.x * Screen.width, mousePosition.y * Screen.height, 0.0f);
		gameObject.GetComponent<Rigidbody2D>().MovePosition(mousePosition);
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.name.Contains("pierre")) {
			m_HitStone.time = 0.8f;
			m_HitStone.Play();
		}
	}
}