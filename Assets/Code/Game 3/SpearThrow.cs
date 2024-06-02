using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SpearThrow : MonoBehaviour
{
    [SerializeField] private RectTransform m_Spear;
    [SerializeField] private float m_SpearSpeed;
    [SerializeField] private GameObject m_Ui;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Vector2 m_Size;
    [SerializeField] private GameObject m_LanceLayer;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // GameObject toSpawn = InstantiateToSpawn(m_LanceLayer);
    }



    public void OnClick() {
        // transform.position = transform.position + mousePosition * SpearSpeed * Time.deltaTime;

        Vector3 mouseScreenPosition = Input.mousePosition;

         Vector3 mouseViewportPosition = mainCamera.ScreenToViewportPoint(mouseScreenPosition);
         Debug.Log("c chouette" + mouseScreenPosition);

         m_Spear.anchoredPosition = mouseScreenPosition;
         Debug.Log(m_Spear.anchoredPosition);
         InstantiateToSpawn();

    }

    private RectTransform InstantiateToSpawn(){
        
        RectTransform toSpawn = Instantiate(m_Spear, m_Spear.anchoredPosition, Quaternion.identity);
        toSpawn.transform.SetParent(m_Ui.transform);
        return toSpawn;
    }

    private Vector2 SetSize(){
        Vector2 size = new Vector2(Screen.width * m_Size.x, Screen.height * m_Size.y);

        return size;
    }
}
