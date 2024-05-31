using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	[Header("Character Settings")]
	[SerializeField] private Image m_Character;
	[SerializeField] private float m_FadeRate;
	[SerializeField] private float m_FadeMultiplicator = 1.0f;
	[Space, Header("Intro Text Settings")]
	[SerializeField] private float m_PlayRate = 1.0f;
	[SerializeField] public Sprite[] m_IntroText;
	[Space, Header("Init Gameplay Settings")]
	[SerializeField] private Chrono m_Chrono;
	[SerializeField] private Image m_Image;
	[Space, Header("End Screen Settings")]
	[SerializeField] private GameObject m_EndScreen;
	[SerializeField] private GameObject[] m_Screens;
	
	[SerializeField] private AudioSource m_Pop;

	private Coroutine m_SpawnCharacterCoroutine;
	private Coroutine m_IntroCoroutine;

	[HideInInspector]
	public int m_Cpt = 0;

	[SerializeField] GameObject m_Pause;
	private bool m_IsGamePaused = false;
	[SerializeField] private GameObject m_Options;

	private void Start() {
		Time.timeScale = 1;
		m_Character.color = new Color(255, 255, 255, 0);
		m_Character.enabled = true;
		StartCoroutine(SpawnAnim(m_Character, m_FadeMultiplicator));

		if(m_IntroText.Length > 0)
			StartCoroutine(PlayIntro());
	}

	private IEnumerator SpawnAnim(Image toAnim, float fadeMultiplicator, float timeBeforeDespawn = 0.0f) {
		yield return new WaitForSeconds(m_FadeRate);

		toAnim.color = new Color(255, 255, 255, toAnim.color.a + fadeMultiplicator * Time.fixedDeltaTime);

		if(toAnim.color.a < 1) {
			m_SpawnCharacterCoroutine = StartCoroutine(SpawnAnim(toAnim, fadeMultiplicator, timeBeforeDespawn));
		}else if(timeBeforeDespawn > 0.0f) {
			yield return new WaitForSeconds(timeBeforeDespawn);
			StartCoroutine(DespawnAnim(toAnim, fadeMultiplicator * -1));
		}
	}

	private IEnumerator DespawnAnim(Image toAnim, float fadeMultiplicator) {
		yield return new WaitForSeconds(m_FadeRate);

		toAnim.color = new Color(255, 255, 255, toAnim.color.a + fadeMultiplicator * Time.fixedDeltaTime);

		if(toAnim.color.a > 0)
			StartCoroutine(DespawnAnim(toAnim, fadeMultiplicator));
	}

	private IEnumerator PlayIntro() {
		m_Pop.Play();
		m_Image.sprite = m_IntroText[m_Cpt];
		StartCoroutine(SpawnAnim(m_Image, m_FadeMultiplicator, m_PlayRate / 4.0f));
		m_Cpt++;

		yield return new WaitForSeconds(m_PlayRate);

		if(m_Cpt < m_IntroText.Length)
			m_IntroCoroutine = StartCoroutine(PlayIntro());
		else {
			StartCoroutine(DespawnAnim(m_Character, m_FadeMultiplicator * - 1));
			StartGame();
		}
	}

	private void StartGame() {
		m_Chrono.StartChrono();
	}

	public void ShowScreen(int screen) {
		m_Screens[screen].SetActive(true);
	}

	private void Update() {
		if(Input.GetKeyDown(KeyCode.Escape)) {
			if(m_IsGamePaused)
				ContinueGame();
			else
				PauseGame();
		}
	}

	public void ContinueGame() {
		if(!m_Options.activeInHierarchy) {
			Time.timeScale = 1;
			m_Pause.SetActive(false);
			GameObject.Find("UI").GetComponent<CursorOnScreen>().SetupCursor();
			m_IsGamePaused = false;
		}
	}

	private void PauseGame() {
		if(!m_Screens[0].activeInHierarchy && !m_Screens[1].activeInHierarchy) {
			Time.timeScale = 0;
			m_Pause.SetActive(true);
			GameObject.Find("PauseUI").GetComponent<CursorOnScreen>().SetupCursor();
			m_IsGamePaused = true;
		}
	}
}