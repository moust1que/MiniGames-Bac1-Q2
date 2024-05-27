using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using UnityEditor.Tilemaps;
using UnityEngine;

public class OryxMovement : MonoBehaviour
{

    [SerializeField] private Vector3 vitesse;
  
    private void Start()
    {
        
    }

    void Update()
    {
        // transform.position = transform.position + new Vector3(UnityEngine.Random.Range(-500.0f, 300.0f), UnityEngine.Random.Range(-500.0f, 300.0f), 0) * Time.deltaTime;

        transform.position = transform.position + vitesse * Time.deltaTime;

    }
}
