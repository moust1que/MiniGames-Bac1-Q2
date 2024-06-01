using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Game3 : MonoBehaviour {
	[Header("GameManager")]
	[SerializeField] private GameManager m_GameManager;
	[Space, Header("Object To Spawn")]
	[SerializeField] private ToSpawn m_ToSpawn;

	private bool m_Spawning = false;

    public bool WinOrLose() {
		return true;
	}

	private void FixedUpdate() {
		if(m_GameManager.m_Cpt >= m_GameManager.m_IntroText.Length && !m_Spawning) {
			m_Spawning = true;
			StartGame();
		}
	}

	private void StartGame() {
		m_ToSpawn.StartSpawn();
	}	
}