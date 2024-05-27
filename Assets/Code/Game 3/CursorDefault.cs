using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class CursorDefault : MonoBehaviour
{
    [SerializeField] private Texture2D m_CursorTexture;

    private void Start()
    {
        Cursor.SetCursor(m_CursorTexture, new Vector2(0.0f, 1.0f), CursorMode.Auto);
    }

}
