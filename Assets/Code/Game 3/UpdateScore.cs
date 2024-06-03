using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateScore : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI m_Text;

	public void UpdateText(int score) {
		m_Text.text = $"{score}/5";
	}
}