using UnityEngine;

public class CursorOnScreen : MonoBehaviour {
    [SerializeField] private Texture2D m_CursorTexture;
	[SerializeField] private CursorMode m_CursorMode = CursorMode.Auto;
	[SerializeField] private Vector2 m_Hotspot = new Vector2(0.0f, 32.0f);

    private void Start() {
        SetupCursor();
    }

	public void SetupCursor() {
        Cursor.SetCursor(m_CursorTexture, m_Hotspot, m_CursorMode);
	}
}