using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GetRessources : MonoBehaviour {
	[SerializeField] private GM_Game2 m_GM;
	[SerializeField] private GameObject m_ItemCollected;

	public void Clicked() {
		m_GM.AddItemOnMouse(m_ItemCollected);
	}
}