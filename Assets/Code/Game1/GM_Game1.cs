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

	private void FixedUpdate() {
		if(m_Score == 0 || m_Score == 100)
			m_GameManager.EndGame();

		if(m_Score == 0)
			m_Fire.Stop();
	}

	public void StartGame() {
		m_ToSpawn.StartSpawn();
	}

	public bool WinOrLose() {
		if(m_Score >= 60)
			return true;
		else
			return false;
	}
}