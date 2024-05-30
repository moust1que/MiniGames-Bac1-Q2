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
	[SerializeField] private Sprite[] m_IntroText;
	[Space, Header("Init Gameplay Settings")]
	[SerializeField] private Chrono m_Chrono;
	[SerializeField] private Image m_Image;
	[SerializeField] private ToSpawn m_ToSpawn;
	[Space, Header("End Screen Settings")]
	[SerializeField] private GameObject m_EndScreen;
	[SerializeField] private GameObject[] m_Screens;

	private Coroutine m_SpawnCharacterCoroutine;
	private Coroutine m_IntroCoroutine;

	public int m_Score = 30;
	private int m_Cpt = 0;

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
		m_ToSpawn.StartSpawn();
	}

	private void FixedUpdate() {
		if(m_Score == 0 || m_Score == 100)
			EndGame();
	}

	public void EndGame() {
		if(m_Score >= 60)
			ShowScreen(0);
		else
			ShowScreen(1);
		
		Time.timeScale = 0;
	}

	private void ShowScreen(int screen) {
		m_Screens[screen].SetActive(true);
	}
}