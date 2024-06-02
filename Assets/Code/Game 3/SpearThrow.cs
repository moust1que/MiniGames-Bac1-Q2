using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SpearThrow : MonoBehaviour
{
    [SerializeField] private GameObject m_SpearPrefab;
    [SerializeField] private float m_SpearSpeed;
    [SerializeField] private GameObject m_Ui;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Vector2 m_Size;
    [SerializeField] private RectTransform m_LanceLayer;
    [SerializeField] private GameObject m_SpearP;
    [SerializeField] Vector3 teste = new();
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private GameObject m_SpearPosition; 




    // Start is called before the first frame update
    void Start()
    {
        m_SpearP.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // GameObject toSpawn = InstantiateToSpawn(m_LanceLayer);
    }

    void FixedUpdate(){
        if(m_SpearPrefab){
            // m_SpearPrefab.transform.position = teste
            // m_SpearPrefab.transform.position = Vector3.Lerp(m_SpearPrefab.transform.position, targetPosition, m_SpearSpeed * Time.deltaTime);
            m_SpearPrefab.transform.position = m_SpearPrefab.transform.position + targetPosition * m_SpearSpeed * Time.deltaTime;
            Debug.Log("wsh " + m_SpearPrefab.transform.position);
        }
    }

    public void OnClick() {
        // transform.position = transform.position + mousePosition * SpearSpeed * Time.deltaTime;

        Vector3 mouseScreenPosition = Input.mousePosition;
        // targetPosition = mouseScreenPosition;
        // targetPosition = mainCamera.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, mainCamera.nearClipPlane));
       
         Debug.Log("c chouette" + mouseScreenPosition);

        m_SpearP.SetActive(false);
         InstantiateToSpawn(mouseScreenPosition);
         StartCoroutine(SpearCoroutine()); 
             
    }

    IEnumerator SpearCoroutine(){
        yield return new WaitForSeconds(1.5f);
        m_SpearP.SetActive(true);
    }

    private GameObject InstantiateToSpawn(Vector3 mousePosition){
        Vector3 parentPos = m_SpearPosition.transform.position;
        GameObject toSpawn = Instantiate(m_SpearPrefab, m_SpearPosition.transform.position, Quaternion.identity);
        toSpawn.transform.SetParent(m_Ui.transform);
        toSpawn.GetComponent<RectTransform>().sizeDelta = SetSize();
        // m_SpearPrefab.transform.position = mousePosition; 
        
        return toSpawn;
    }

    private Vector2 SetSize(){
        Vector2 size = new Vector2(Screen.width * m_Size.x, Screen.height * m_Size.y);
        return size;
    }
}
