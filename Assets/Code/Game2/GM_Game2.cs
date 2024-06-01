using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Game2 : MonoBehaviour {
	[Header("Ressources Settings")]
	[SerializeField] private GameObject[] m_Ressources;

	public void StartGame() {
		foreach(GameObject ressource in m_Ressources) {
			ressource.SetActive(true);
		}
	}

	public bool WinOrLose() {
		return true;
	}
}