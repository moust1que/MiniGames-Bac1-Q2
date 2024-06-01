using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Game3 : MonoBehaviour {
	[Space, Header("Object To Spawn")]
	[SerializeField] private ToSpawn m_ToSpawn;


	public void StartGame() {
		m_ToSpawn.StartSpawn();
	}

    public bool WinOrLose() {
		return true;
	}
}