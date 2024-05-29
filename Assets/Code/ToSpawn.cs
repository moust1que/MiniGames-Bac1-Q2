using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ToSpawn : MonoBehaviour {
    [SerializeField] private GameObject[] m_ToSpawnPrefab;
    [SerializeField] private float m_SpawnRate = 2.0f;
	[SerializeField] private float m_DestroyRate = 3.0f;
	[SerializeField] private GameObject[] m_Paths;
	[SerializeField] private Vector2[] m_Sizes;

	private Coroutine m_SpawnCoroutine;
	private Coroutine m_DestroyCoroutine;

	private IEnumerator SpawnCoroutine() {
		yield return new WaitForSeconds(m_SpawnRate);

		int side = Random.Range(0, m_ToSpawnPrefab.Length);
		int path = Random.Range(0, m_Paths.Length);
		GameObject toSpawn = InstantiatetoSpawn(side, path);
		toSpawn.transform.SetParent(m_Paths[path].transform);
		toSpawn.GetComponent<RectTransform>().sizeDelta = m_Sizes[path];

		StartCoroutine(DestroyCoroutine(toSpawn));
		m_SpawnCoroutine = StartCoroutine(SpawnCoroutine());
	}

	private GameObject InstantiatetoSpawn(int side, int path) {
		Vector3 parentPos = m_Paths[path].transform.position;
		Vector3 parentScale = m_Paths[path].GetComponent<RectTransform>().sizeDelta;
		Vector3 spawnPos = new Vector3(parentPos.x + parentScale.x * side, parentPos.y, parentPos.z);

		GameObject toSpawn = Instantiate(m_ToSpawnPrefab[side], spawnPos, Quaternion.identity);

		return toSpawn;
	}

	private IEnumerator DestroyCoroutine(GameObject toDestroy) {
		yield return new WaitForSeconds(m_DestroyRate);

		Destroy(toDestroy);
	}

	public void StartSpawn() {
		StartCoroutine(SpawnCoroutine());
	}
}