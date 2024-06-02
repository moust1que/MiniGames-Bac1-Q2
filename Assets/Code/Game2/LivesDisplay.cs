using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesDisplay : MonoBehaviour {
	[SerializeField] private GM_Game2 m_GM;
    [SerializeField] private TextMeshProUGUI m_Text;

	public void SetNewLives() {
		m_Text.text = $"{m_GM.m_Lives}";
	}
}