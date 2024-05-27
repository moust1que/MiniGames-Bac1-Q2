using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemiesHandler : MonoBehaviour {
	[SerializeField] private Texture2D m_EnemiesText;
	[SerializeField] private Texture2D[] m_DropsText;
	[SerializeField] private GameObject m_EnemiesArea;
	[SerializeField] private float m_SpawnRate = 1.0f;

	private Coroutine m_SpawnCoroutine;

	private void Start() {
		StartCoroutine(SpawnCoroutine());
	}

	private IEnumerator SpawnCoroutine() {
		yield return new WaitForSeconds(m_SpawnRate);

		SpawnEnemy();

		Debug.Log("Spawn");

		m_SpawnCoroutine = StartCoroutine(SpawnCoroutine());
	}

	private void SpawnEnemy() {
		Vector2 coordinates;

		coordinates = new Vector2(SetSpawnSide(), SetSpawnHeight());
	}

	private int SetSpawnSide() {
		int side = Random.Range(0, 2);

		Debug.Log($"Side = {side}");

		if(side == 1)
			return (int) m_EnemiesArea.GetComponent<RectTransform>().rect.width;
		else
			return 0;
	}

	private int SetSpawnHeight() {
		return 0;
	}
}