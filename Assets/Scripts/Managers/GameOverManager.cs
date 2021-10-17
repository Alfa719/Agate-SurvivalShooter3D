using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Text warningText;
    public PlayerHealth playerHealth;       
    public float restartDelay = 8f;            

    Animator anim;                          
    float restartTimer;                    

    void Awake()
    {
        anim = GetComponent<Animator>();
        restartTimer = 0;
    }
    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetBool("GameOver", true);
            restartTimer += Time.deltaTime;
            if (restartTimer >= restartDelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
    public void ShowWarning(float enemyDistance)
    {
        warningText.text = string.Format("! {0} m", Mathf.RoundToInt(enemyDistance));
        anim.SetTrigger("Warning");
    }
}