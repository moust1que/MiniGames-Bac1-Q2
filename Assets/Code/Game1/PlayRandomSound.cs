using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayRandomSound : MonoBehaviour {
    [SerializeField] private AudioSource m_Audio;

	private void Start() {
		StartCoroutine(RandomSound());
	}

	private IEnumerator RandomSound() {
		yield return new WaitForSeconds(Random.Range(2.0f, 8.0f));

		m_Audio.Play();

		StartCoroutine(RandomSound());
	}
}