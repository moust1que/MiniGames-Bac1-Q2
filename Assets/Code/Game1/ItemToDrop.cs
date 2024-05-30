using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ItemToDrop : MonoBehaviour {
	[SerializeField] private GameObject[] m_Items;

	private void Start() {
		int itemChoice = Random.Range(0, 2);
		GameObject item = Instantiate(m_Items[itemChoice], gameObject.transform.position, Quaternion.identity);
		item.transform.SetParent(gameObject.transform, false);
		item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		item.GetComponent<RectTransform>().sizeDelta = SetSize();
	}

	private Vector2 SetSize() {
		Vector2 size = new Vector2(Screen.width * 0.04f, Screen.width * 0.04f);

		return size;
	}
}