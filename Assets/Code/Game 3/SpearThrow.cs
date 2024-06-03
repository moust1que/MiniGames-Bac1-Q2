using System.Collections;
using UnityEngine;

public class SpearThrow : MonoBehaviour {
    [SerializeField] private GameObject m_Hand;
    [SerializeField] private GameObject m_SpearP;
	[SerializeField] private AudioSource m_SpearLaunch;

	private GameObject m_ToSpawn;
	private Vector3 m_MouseScreenPosition;

	private void Start() {
		m_SpearP.SetActive(true);
	}

    public void OnClick() {
		m_MouseScreenPosition = Input.mousePosition;

        if(m_SpearP.activeInHierarchy) {
			InstantiateToSpawn();
			m_SpearP.SetActive(false);
			m_ToSpawn.GetComponent<SpearMovement>().TravelToTarget(m_MouseScreenPosition);
			StartCoroutine(SpearCoroutine());
		} 
    }

    IEnumerator SpearCoroutine() {
        yield return new WaitForSeconds(1.5f);
        m_SpearP.SetActive(true);
    }

    private void InstantiateToSpawn(){
        m_ToSpawn = Instantiate(m_SpearP, m_Hand.transform.position, Quaternion.identity);
        m_ToSpawn.transform.SetParent(m_Hand.transform);
		m_SpearLaunch.Play();
    }
}