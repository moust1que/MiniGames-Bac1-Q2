using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Game1 : MonoBehaviour {
	[Header("GameManager")]
	[SerializeField] private GameManager m_GameManager;
	[Space, Header("Object To Spawn")]
	[SerializeField] private ToSpawn m_ToSpawn;
	[Space, Header("Sounds")]
	[SerializeField] private AudioSource m_Fire;
	
	public int m_Score = 30;

	private bool m_Spawning = false;

	private void FixedUpdate() {
		if(m_GameManager.m_Cpt >= m_GameManager.m_IntroText.Length && !m_Spawning) {
			m_Spawning = true;
			StartGame();
		}

		if(m_Score == 0 || m_Score == 100)
			m_GameManager.EndGame();

		if(m_Score == 0)
			m_Fire.Stop();
	}

	private void StartGame() {
		m_ToSpawn.StartSpawn();
	}

	public bool WinOrLose() {
		if(m_Score >= 60)
			return true;
		else
			return false;
	}
}