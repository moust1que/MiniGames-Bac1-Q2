using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour {
	[SerializeField] private GameObject m_Options;
	[SerializeField] private GameObject m_Previous;

	public void DisplayOptions() {
		m_Previous.SetActive(false);
		m_Options.SetActive(true);
		GameObject.Find("BackBtn").GetComponent<Options>().m_Previous = m_Previous;
	}

	public void DisplayPrevious() {
		m_Options.SetActive(false);
		m_Previous.SetActive(true);
	}
}