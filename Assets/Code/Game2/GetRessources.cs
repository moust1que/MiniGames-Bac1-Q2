using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GetRessources : MonoBehaviour {
	[SerializeField] private GM_Game2 m_GM;
	[SerializeField] private GameObject m_ItemCollected;
	[SerializeField] private AudioSource m_ToolsSounds;

	public void Clicked() {
		m_GM.AddItemOnMouse(m_ItemCollected);
		switch(m_ItemCollected.name) {
			case "Dirt":
				m_ToolsSounds.Play();
			break;
			case "Plank":
				m_ToolsSounds.Play();
			break;
			case "Stone":
				m_ToolsSounds.Play();
			break;
			case "Straw":
				m_ToolsSounds.Play();
			break;
			case "Water":
				m_ToolsSounds.Play();
			break;
		}
	}
}