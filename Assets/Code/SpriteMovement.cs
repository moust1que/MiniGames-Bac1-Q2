using UnityEngine;

public class SpriteMovement : MonoBehaviour {
    [SerializeField] private Vector3 vitesse;
	[SerializeField] private float m_VerticalDisplacement = 1.0f;
	[SerializeField] private float m_VerticalSpeed = 1.0f;

	Coroutine m_VerticalDisplacementCoroutine;
	float m_Origins;

	private void Start() {
		m_Origins = transform.position.y;
	}

    private void Update() {
        transform.position = transform.position + vitesse * Time.deltaTime;
		if(m_VerticalSpeed != 0)
			ApplyVerticalDisplacement();
    }

	private void ApplyVerticalDisplacement() {
		transform.position = new Vector3(transform.position.x, transform.position.y + m_VerticalSpeed * Time.deltaTime, transform.position.z);

		if(transform.position.y > m_Origins + m_VerticalDisplacement || transform.position.y < m_Origins - m_VerticalDisplacement)
			m_VerticalSpeed *= -1;
	}
}