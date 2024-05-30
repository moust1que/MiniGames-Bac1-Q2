using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFellInFire : MonoBehaviour {
	[SerializeField] private GameManager m_GameManager;

	private GameObject m_Item;

	private void OnTriggerEnter2D(Collider2D triggerObject) {
		if(triggerObject.name != "MouseCollider") {
			m_Item = triggerObject.gameObject;
			m_Item.GetComponent<ItemFall>().StopFall();
			m_Item.transform.SetParent(null);
				
			if(m_Item.name.Contains("pierre") && m_GameManager.m_Score >= 10)
				m_GameManager.m_Score -= 10;
			else if(m_Item.name.Contains("branche") && m_GameManager.m_Score <= 90)
				m_GameManager.m_Score += 10;

			Destroy(m_Item);
		}
	}
}