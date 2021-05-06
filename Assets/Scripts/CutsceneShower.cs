using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneShower : MonoBehaviour
{
    public GameObject cutscenePrefab;
    public GameController controller;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            controller.ShowCutscene(cutscenePrefab);
        }
    }
}
