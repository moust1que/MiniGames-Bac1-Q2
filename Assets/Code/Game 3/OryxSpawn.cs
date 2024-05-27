using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class OryxSpawn : MonoBehaviour
{

    [SerializeField]
    private GameObject oryxPrefab;
    [SerializeField]
    private float sapwnTime = 2;
    public float spawnRight = 1200;

    private float timer;


    void Start()
    {
        
    }

    void Update()
    {
        timer = timer + Time.deltaTime;

        if (timer > sapwnTime)
        {
            float randomY = UnityEngine.Random.Range(100, 350);
            Vector3 randomPosition = new Vector3(spawnRight, randomY, 0);
            GameObject spawnedOryx = Instantiate(oryxPrefab, randomPosition, quaternion.identity);
            OryxMovement oryx = spawnedOryx.GetComponent<OryxMovement>();
           
            timer = timer - sapwnTime;

        }
    }

}
