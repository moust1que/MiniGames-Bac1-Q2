using UnityEngine;

public class SpriteMovement : MonoBehaviour {
    [SerializeField] private float m_Speed;
	[SerializeField] private float m_VerticalDisplacement = 1.0f;
	[SerializeField] private float m_VerticalSpeed = 1.0f;

	private float m_Origins;
	private Vector3 m_SpeedCoef = new Vector3(0.31f, 0, 0);
	private float m_VerticalCoef = 0.03f;

	private void Start() {
		m_Origins = transform.position.y;
	}

    private void FixedUpdate() {
        transform.position = transform.position + Screen.width * m_SpeedCoef * m_Speed * Time.fixedDeltaTime;
		if(m_VerticalSpeed != 0)
			ApplyVerticalDisplacement();
    }

	private void ApplyVerticalDisplacement() {
		transform.position = new Vector3(transform.position.x, transform.position.y + m_VerticalSpeed * Screen.height * m_VerticalCoef * Time.fixedDeltaTime, transform.position.z);

		if(transform.position.y > m_Origins + m_VerticalDisplacement * Screen.height * m_VerticalCoef || transform.position.y < m_Origins - m_VerticalDisplacement * Screen.height * m_VerticalCoef)
			m_VerticalSpeed *= -1;
	}
}