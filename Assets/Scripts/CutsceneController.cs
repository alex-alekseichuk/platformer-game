using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public void SkipCutscene()
    {
        Destroy(transform.gameObject);
        Time.timeScale = 1;
    }
}
