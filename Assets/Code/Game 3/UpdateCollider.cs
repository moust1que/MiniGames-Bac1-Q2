using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCollider : MonoBehaviour {
    void Start() {
        Vector2 newScale = new Vector2(Screen.width * 0.1f, Screen.height * 0.082f);

		gameObject.GetComponent<BoxCollider2D>().size = newScale;
    }
}