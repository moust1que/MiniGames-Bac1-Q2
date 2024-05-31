using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFellInFire : MonoBehaviour {
	[SerializeField] private GM_Game1 m_GM;
	[SerializeField] private AudioSource m_Burn;
	[SerializeField] private AudioSource m_FireLvlUp;
	[SerializeField] private AudioSource m_FireLvlUp2;
	[SerializeField] private AudioSource m_RockFall;
	[SerializeField] private AudioSource m_StickFall;

	private GameObject m_Item;

	private void OnTriggerEnter2D(Collider2D triggerObject) {
		if(triggerObject.name != "MouseCollider") {
			m_Item = triggerObject.gameObject;
			m_Item.GetComponent<ItemFall>().StopFall();
			m_Item.transform.SetParent(null);
				
			if(m_Item.name.Contains("pierre") && m_GM.m_Score >= 10) {
				m_RockFall.Play();
				m_GM.m_Score -= 10;
			}else if(m_Item.name.Contains("branche") && m_GM.m_Score <= 90) {
				m_FireLvlUp.Play();
				m_FireLvlUp2.Play();
				m_StickFall.Play();
				m_GM.m_Score += 10;
			}
				
			m_Burn.Play();

			Destroy(m_Item);
		}
	}
}