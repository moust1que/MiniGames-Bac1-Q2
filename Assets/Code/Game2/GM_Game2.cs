using UnityEngine;

public class GM_Game2 : MonoBehaviour {
	[SerializeField] public GameManager m_GameManager;
	[Header("Ressources Settings")]
	[SerializeField] private GameObject[] m_Ressources;
	[SerializeField] private GameObject m_Item;
	
	private Vector3 m_MouseScreenPosition;

	public bool m_OnMouse = false;

	public GameObject m_ObjectToAddOnMouse;

	public int m_Lives = 3;

	public void StartGame() {
		foreach(GameObject ressource in m_Ressources) {
			ressource.SetActive(true);
		}
	}

	public bool WinOrLose() {
		if(m_Lives == 0)
			return false;
		
		return true;
	}

	public void AddItemOnMouse(GameObject item) {
		if(!m_OnMouse) {
			m_OnMouse = true;
			m_ObjectToAddOnMouse = item;
			
			m_ObjectToAddOnMouse = Instantiate(m_ObjectToAddOnMouse, new Vector3(m_Item.transform.position.x + Screen.width * 32 / 1920, m_Item.transform.position.y - Screen.width * 32 / 1920, m_Item.transform.position.z), Quaternion.identity);

			m_ObjectToAddOnMouse.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width * 70 / 1920, Screen.width * 70 / 1920);
			m_ObjectToAddOnMouse.transform.SetParent(m_Item.transform);
		}else {
			RemoveItemOnMouse();
			m_OnMouse = false;
			AddItemOnMouse(item);
		}
	}

	private void Update() {
		m_MouseScreenPosition = Input.mousePosition;
		m_Item.transform.position = new Vector2(m_MouseScreenPosition.x, m_MouseScreenPosition.y);
	}

	private void FixedUpdate() {
		if(m_Lives == 0)
			m_GameManager.EndGame();
	}

	public void RemoveItemOnMouse() {
		Destroy(m_ObjectToAddOnMouse);
	}
}