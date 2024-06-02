using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Game2 : MonoBehaviour {
	[Header("Ressources Settings")]
	[SerializeField] private GameObject[] m_Ressources;
	[SerializeField] private GameObject m_Item;
	
	private Vector3 m_MouseScreenPosition;
	private Vector3 m_MouseWorldPosition;

	private bool m_OnMouse = false;

	private GameObject m_ObjectToAddOnMouse;

	public void StartGame() {
		foreach(GameObject ressource in m_Ressources) {
			ressource.SetActive(true);
		}
	}

	public bool WinOrLose() {
		return true;
	}

	public void AddItemOnMouse(GameObject item) {
		Debug.Log(m_ObjectToAddOnMouse);
		if(!m_OnMouse) {
			m_OnMouse = true;
			m_ObjectToAddOnMouse = item;
			m_ObjectToAddOnMouse = Instantiate(m_ObjectToAddOnMouse, new Vector3(m_Item.transform.position.x + 60, m_Item.transform.position.y - 60, m_Item.transform.position.z), Quaternion.identity);
			m_ObjectToAddOnMouse.transform.SetParent(m_Item.transform);
		}
		Debug.Log(m_ObjectToAddOnMouse);
	}

	private void Update() {
		m_MouseScreenPosition = Input.mousePosition;
		m_Item.transform.position = m_MouseScreenPosition;
	}
}