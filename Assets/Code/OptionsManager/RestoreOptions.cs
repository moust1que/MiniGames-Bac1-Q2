using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestoreOptions : MonoBehaviour {
	[SerializeField] private Slider m_GlobalVolume;
	[SerializeField] private Slider m_MusicVolume;
	[SerializeField] private Slider m_SEVolume;

	private void Start() {
		float mainVolume = StaticOptions.mainVolume;
		float musicVolume = StaticOptions.musicVolume;
		float sEVolume = StaticOptions.sEVolume;

		m_GlobalVolume.value = mainVolume;
		m_MusicVolume.value = musicVolume;
		m_SEVolume.value = sEVolume;
	}
}