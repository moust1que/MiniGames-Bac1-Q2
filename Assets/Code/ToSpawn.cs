using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ToSpawn : MonoBehaviour {
    [SerializeField] private GameObject[] m_ToSpawnPrefab;
    [SerializeField] private float m_SpawnRate = 2.0f;
	[SerializeField] private GameObject[] m_Paths;
	[SerializeField] private Vector2 m_Sizes;

	private Coroutine m_SpawnCoroutine;
	private Coroutine m_DestroyCoroutine;

	private const float m_DestroyCoef = 0.005f;

	private IEnumerator SpawnCoroutine() {
		int side = Random.Range(0, m_ToSpawnPrefab.Length);
		int path = Random.Range(0, m_Paths.Length);
		GameObject toSpawn = InstantiatetoSpawn(side, path);
		toSpawn.transform.SetParent(m_Paths[path].transform);
		toSpawn.GetComponent<RectTransform>().sizeDelta = SetSize();
		
		yield return new WaitForSeconds(m_SpawnRate);

		StartCoroutine(DestroyCoroutine(toSpawn));
		m_SpawnCoroutine = StartCoroutine(SpawnCoroutine());
	}

	private GameObject InstantiatetoSpawn(int side, int path) {
		Vector3 parentPos = m_Paths[path].transform.position;
		Vector3 parentScale = m_Paths[path].GetComponent<RectTransform>().sizeDelta;
		Vector3 spawnPos = new Vector3(parentPos.x + Screen.width / 2 * (side == 0 ? -1 : 1), parentPos.y, parentPos.z);

		GameObject toSpawn = Instantiate(m_ToSpawnPrefab[side], spawnPos, Quaternion.identity);

		return toSpawn;
	}

	private IEnumerator DestroyCoroutine(GameObject toDestroy) {
		yield return new WaitForSeconds(m_DestroyCoef * Camera.main.pixelWidth);

		Destroy(toDestroy);
	}

	public void StartSpawn() {
		StartCoroutine(SpawnCoroutine());
	}

	private Vector2 SetSize() {
		Vector2 size = new Vector2(Screen.width * m_Sizes.x, Screen.height * m_Sizes.y);

		return size;
	}
}