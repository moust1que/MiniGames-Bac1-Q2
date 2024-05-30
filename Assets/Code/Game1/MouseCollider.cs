using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCollider : MonoBehaviour {
	

	private void Update() {
		Vector3 mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
		mousePosition = new Vector3(mousePosition.x * Screen.width, mousePosition.y * Screen.height, 0.0f);
		gameObject.GetComponent<Rigidbody2D>().MovePosition(mousePosition);
	}
}