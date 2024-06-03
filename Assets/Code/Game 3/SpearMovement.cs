using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class SpearMovement : MonoBehaviour {
	[SerializeField] private GM_Game3 m_GM;
	[SerializeField] private UpdateScore m_Text;
	[SerializeField] private float m_Speed = 1.0f;
	[SerializeField] private AudioSource m_OryxScream;
	[SerializeField] private AudioSource m_SpearHit;

	private bool m_traveling = false;
	private Vector3 m_Target;
	private Vector3 m_Diff;
	private Vector3 m_NormalizedVector;
	private Vector3 m_Approximated;
	private float m_Precision = 0.1f;

	public void TravelToTarget(Vector3 mouseCoord) {
		m_Target = mouseCoord;
		m_Diff = m_Target - gameObject.transform.position;
		m_Approximated = ApproximateVector3(m_Diff, m_Precision);
		m_NormalizedVector = m_Approximated.normalized;
		m_traveling = true;
	}

	private void FixedUpdate() {
		if(m_traveling) {
			transform.position = transform.position + Screen.width * m_Speed * m_NormalizedVector * Time.fixedDeltaTime;
		}
	}

	private Vector3 ApproximateVector3(Vector3 vector, float precision) {
		float x = Mathf.Round(vector.x / precision) * precision;
		float y = Mathf.Round(vector.y / precision) * precision;
		float z = 0.0f;

		return new Vector3(x, y, z);
	}

	private void OnTriggerEnter2D(Collider2D collider) {
		Destroy(collider.gameObject);
		m_SpearHit.Play();
		m_OryxScream.Play();
		m_GM.m_NbOryxKill++;
		m_Text.UpdateText(m_GM.m_NbOryxKill);
	}
}