using System.Collections;
using TMPro;
using UnityEngine;

public class Chrono : MonoBehaviour {
	[SerializeField] private TextMeshProUGUI m_TimerText;
	[SerializeField] private float m_Time;

	private Coroutine m_TimeCoroutine;

	private void Start() {
		ToMinutesAndSeconds();
		StartCoroutine(TimeCoroutine());
	}

	private void ToMinutesAndSeconds() {
		int minutes, seconds;

		minutes = (int) Mathf.Floor(m_Time / 60);
		seconds = (int) Mathf.Floor(m_Time % 60);

		SetOnScreen(minutes, seconds);
	}

	private void SetOnScreen(int minutes, int seconds) {
		string minutesText = minutes < 10 ? $"0{minutes}" : $"{minutes}";
		string secondsText = seconds < 10 ? $"0{seconds}" : $"{seconds}";
		m_TimerText.text = $"{minutesText}:{secondsText}";
	}

	private IEnumerator TimeCoroutine() {
		yield return new WaitForSeconds(1);

		m_Time--;
		ToMinutesAndSeconds();

		if(m_Time == 0)
			StopCoroutine(m_TimeCoroutine);
		else
			m_TimeCoroutine = StartCoroutine(TimeCoroutine());
	}
}