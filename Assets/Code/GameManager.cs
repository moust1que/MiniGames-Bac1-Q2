using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	[SerializeField] private float m_PlayRate = 1.0f;
	[SerializeField] private Sprite[] m_IntroText;
	[Space]
	[SerializeField] private Chrono m_Chrono;
	[SerializeField] private Image m_Image;
	[SerializeField] private ToSpawn m_ToSpawn;
	[Space]
	[SerializeField] private GameObject m_EndScreen;
	[SerializeField] private GameObject[] m_Screens;

	private Coroutine m_IntroCoroutine;

	private int m_Score = 80;
	private int m_Cpt = 0;

    private void Start() {
		if(m_IntroText.Length > 0)
			StartCoroutine(PlayIntro());
	}

	private IEnumerator PlayIntro() {
		m_Image.sprite = m_IntroText[m_Cpt];
		m_Cpt++;

		yield return new WaitForSeconds(m_PlayRate);

		if(m_Cpt < m_IntroText.Length)
			m_IntroCoroutine = StartCoroutine(PlayIntro());
		else {
			m_Image.enabled = false;
			StartGame();
		}
	}

	private void StartGame() {
		m_Chrono.StartChrono();
		m_ToSpawn.StartSpawn();
	}

	public void EndGame() {
		if(m_Score >= 60)
			ShowScreen(0);
		else
			ShowScreen(1);
	}

	private void ShowScreen(int screen) {
		m_Screens[screen].SetActive(true);
	}
}