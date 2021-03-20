using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToEnter : MonoBehaviour
{
    [SerializeField] private GameObject PressEUI;
    [SerializeField] private SceneTransition changeLevelScript;
    private bool isPlayerInTrigger = false;
    [SerializeField] private string levelName;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PressEUI.active = true;
            isPlayerInTrigger = true;
        }
    }

    private void Update()
    {
        if (isPlayerInTrigger)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                changeLevelScript.ManagerScene(levelName);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") 
        {
            PressEUI.active = false;
            isPlayerInTrigger = false;
        }
    }
}
