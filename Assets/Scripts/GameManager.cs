
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [HideInInspector] public static GameManager singleton;
    [HideInInspector] public int best;
    [HideInInspector] public int score;
    [HideInInspector] public int currentStage = 0;

    [HideInInspector] public bool replayButtonActivation = false;
    [HideInInspector] public bool nextLevelCalled = false;

    [HideInInspector] public int livesCount = 2;

    private void Awake()
    {
        if (singleton == null)
            singleton = this;
        else if (singleton != this)
            Destroy(gameObject);

        // Load the saved highscore
        best = PlayerPrefs.GetInt("Highscore");
    }

    public void NextLevel()
    {
        //Debug.Log("Next Level");

        currentStage++;
        //Debug.Log(currentStage);
        nextLevelCalled = true;
        FindObjectOfType<BallController>().ResetBall();
        FindObjectOfType<HelixController>().LoadStage(currentStage);
    }

    void RestartLevel()
    {

        //show ads
        singleton.score = 0;
        FindObjectOfType<BallController>().ResetBall(); // another way of calling method from another class

        //Reload the stage as well
        FindObjectOfType<HelixController>().LoadStage(currentStage);
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;

        if (score > best)
        {
            PlayerPrefs.SetInt("Highscore", score);
            best = score;
        }
    }


    public void PauseGame()
    {
        Time.timeScale = 0;
        replayButtonActivation = true;
        
    }


    public void ResumeGame()
    {
        
        RestartLevel();
        Time.timeScale = 1;
        replayButtonActivation = false;
        livesCount--;
    }

    public void RestartGame()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
        replayButtonActivation = false;
    }
}
