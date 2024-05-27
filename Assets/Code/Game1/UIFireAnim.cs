using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIFireAnim : MonoBehaviour {
	[SerializeField] private Image m_Image;

	[SerializeField] private Sprite[] m_SpriteArray;
	[SerializeField] private float m_Speed;

	private int m_IndexSprite = 0;
	private Coroutine m_AnimCoroutine;

	private void Start() {
		StartCoroutine(AnimCoroutine());
	}

	private IEnumerator AnimCoroutine() {
		yield return new WaitForSeconds(m_Speed);
		
		if(m_IndexSprite >= m_SpriteArray.Length)
			m_IndexSprite = 0;

		m_Image.sprite = m_SpriteArray[m_IndexSprite];
		m_IndexSprite++;

		m_AnimCoroutine = StartCoroutine(AnimCoroutine());
	}
}