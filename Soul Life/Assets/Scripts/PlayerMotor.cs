using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Animator movePlayer;
    
    [SerializeField] private GameObject target;

    [SerializeField] private GameObject enterExit;
    [SerializeField] private string sceneToLoad;

    [SerializeField] private float maxRange;
    [SerializeField] private float speed;
    
    private Vector3 distance;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneTransition.SceneManeger("Menu");
        }
    }

    void FixedUpdate()
    {
        distance = target.transform.position - player.transform.position;
        
        if (Input.GetKey(KeyCode.W))
        {
            movePlayer.SetBool("Walk_F", true);
            movePlayer.SetBool("Idle", false);
            movePlayer.SetBool("Walk_B", false);
            movePlayer.speed = speed;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            movePlayer.SetBool("Walk_B", true);
            movePlayer.SetBool("Walk_F", false);
            movePlayer.SetBool("Idle", false);
            movePlayer.speed = speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position += Vector3.left * Input.GetAxisRaw("Horizontal") * speed;
        }
        else if( Input.GetKey(KeyCode.D))
        {
            player.transform.position -= Vector3.left * Input.GetAxisRaw("Horizontal") * speed;
        }

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            movePlayer.SetBool("Idle", true);
            movePlayer.SetBool("Walk_B", false);
            movePlayer.SetBool("Walk_F", false);
        }
        
        if (distance.sqrMagnitude < maxRange * maxRange)
        {
            enterExit.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                print("E pressed!");
                SceneTransition.SceneManeger(sceneToLoad);
            }
        }
        else
        {
            enterExit.SetActive(false);
        }
    }
}