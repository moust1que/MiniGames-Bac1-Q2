using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiggerVerticalDrop : MonoBehaviour {
    private GameObject m_Item;

	private void OnTriggerEnter2D(Collider2D triggerObject) {
		if(triggerObject.name != "MouseCollider") {
			m_Item = triggerObject.gameObject;
			m_Item.transform.SetParent(null);
			m_Item.transform.SetParent(gameObject.transform);
			m_Item.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, m_Item.GetComponent<RectTransform>().anchoredPosition.y);
			m_Item.GetComponent<ItemFall>().StartFall();
		}
	}
}