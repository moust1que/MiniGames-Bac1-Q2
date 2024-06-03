using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScale : MonoBehaviour {
	[SerializeField] private float m_Positif;
    void Start() {
        switch(gameObject.transform.parent.gameObject.name) {
			case "Path1":
				gameObject.transform.localScale = new Vector3(0.33f * m_Positif, 0.33f, 0.0f);
			break;
			case "Path2":
				gameObject.transform.localScale = new Vector3(0.66f * m_Positif, 0.66f, 0.0f);
			break;
			case "Path3":
				gameObject.transform.localScale = new Vector3(1.0f * m_Positif, 1.0f, 0.0f);
			break;
		}
    }
}