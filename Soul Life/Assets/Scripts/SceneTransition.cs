using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public TextMeshProUGUI loadingPercentage;
    public Image loadingProgressBar;
    
    public static SceneTransition instance;
    private static bool shoodPlayAnimation;

    private Animator componentAnimator;
    private AsyncOperation loadingSceneOperation;

    public void ManagerScene(string stringName)
    {
        SceneManeger(stringName);
    }
    public static void SceneManeger(string sceneName)
    {
        instance.componentAnimator.SetTrigger("Scene Start");

        instance.loadingSceneOperation =  SceneManager.LoadSceneAsync(sceneName);
        instance.loadingSceneOperation.allowSceneActivation = false;
        
    }
    
    private void Start()
    {
        instance = this;

        componentAnimator = GetComponent<Animator>();
        
        
        componentAnimator.SetTrigger("Scene Idle");
        if(shoodPlayAnimation) componentAnimator.SetTrigger("Scene End");
    }

    public void OnAnimationOver()
    {
        print("Animation over!");
        loadingSceneOperation.allowSceneActivation = true;
        shoodPlayAnimation = true;
    }

    private void Update()
    {
        if (loadingSceneOperation != null)
        {
            loadingPercentage.text = Mathf.RoundToInt(loadingSceneOperation.progress * 100) + "%";
            loadingProgressBar.fillAmount = loadingSceneOperation.progress;   
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadSceneAsync("Menu");
        }

        if (Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadSceneAsync("worldScene");
        }
    }
}
