using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Game3 : MonoBehaviour {
	[SerializeField] private GameManager m_GameManager;
	[SerializeField] private AudioSource m_OryxRun;
	[SerializeField] private AudioSource m_OryxFond;
	[Space, Header("Object To Spawn")]
	[SerializeField] private ToSpawn m_ToSpawn;

	public int m_NbOryxKill;


	public void StartGame() {
		m_OryxRun.Play();
		m_OryxFond.Play();
		m_ToSpawn.StartSpawn();
	}

    public bool WinOrLose() {
		if(m_NbOryxKill == 5)
			return true;

		return false;
	}

	private void FixedUpdate() {
		if(m_NbOryxKill == 5)
			m_GameManager.EndGame();
	}
}