using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetOptions : MonoBehaviour {
	[SerializeField] private Slider m_GlobalVolume;
	[SerializeField] private Slider m_MusicVolume;
	[SerializeField] private Slider m_SEVolume;

	[SerializeField] private AudioSource[] m_Music;
	[SerializeField] private AudioSource[] m_SE;


	public void UpdateVolume() {
		foreach(AudioSource source in m_Music) {
			source.volume = m_GlobalVolume.value * m_MusicVolume.value;
		}
		foreach(AudioSource source in m_SE) {
			source.volume = m_GlobalVolume.value * m_SEVolume.value;
		}
	}

	public void LoadSceneAndKeepValue(string sceneName) {
		float mainVolume = m_GlobalVolume.value;
		float musicVolume = m_MusicVolume.value;
		float sEVolume = m_SEVolume.value;

		StaticOptions.mainVolume = mainVolume;
		StaticOptions.musicVolume = musicVolume;
		StaticOptions.sEVolume = sEVolume;

		SceneManager.LoadScene(sceneName);
	}
}