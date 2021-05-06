using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    bool isPaused = false;
    bool isInInventory = false;
    bool isInCutscene = false;

    public GameObject PauseMenuPrefab;
    public GameObject InventoryMenuPrefab;
    public Canvas canvas;

    GameObject newInventoryMenu;
    GameObject newPauseMenu;
    private GameObject newCutscene;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == false && isInInventory == false && newCutscene == null)
            {
                isPaused = true;
                Time.timeScale = 0;
                newPauseMenu = Instantiate(PauseMenuPrefab, canvas.transform);
            }
            else if(newPauseMenu != null)
            {
                isPaused = false;
                Time.timeScale = 1;
                Destroy(newPauseMenu);
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isInInventory == false && isPaused == false && newCutscene == null)
            {
                isInInventory = true;
                Time.timeScale = 0;
                newInventoryMenu = Instantiate(InventoryMenuPrefab, canvas.transform);
            }
            else if(newInventoryMenu != null)
            {
                isInInventory = false;
                Time.timeScale = 1;
                Destroy(newInventoryMenu);
            }
        }
    }

    public void ShowCutscene(GameObject Cutscene)
    {
        newCutscene = Instantiate(Cutscene, canvas.transform);
        Time.timeScale = 0;
    }
}
