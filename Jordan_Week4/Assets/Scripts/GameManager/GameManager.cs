using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class GameManager : MonoBehaviour
{
    public int health = 3;
    public int score = 0;
    public float currentTime = 0f;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public bool gameOver;
    public bool isAnimationOver;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        // sets elapsed time
        currentTime += Time.deltaTime;
        timeText.text = "Time:" + Mathf.RoundToInt(currentTime).ToString();
        
        scoreText.text = "Score:" + score.ToString();

        healthText.text = "Health:" + health.ToString();

        if (health <= 0 && !isAnimationOver)
        {
            StartCoroutine(AnimationDelay());
        }
    }
    private IEnumerator AnimationDelay()
    {
        isAnimationOver = true;
        yield return new WaitForSeconds(2);
        Time.timeScale = 0;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
    
}
