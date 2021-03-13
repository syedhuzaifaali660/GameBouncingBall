
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text txtScore;
    public Text txtBest;
    public Text stageCount;
    public Text txtLives;


    public GameObject Replay;
    public GameObject stageUI;

    public GameObject scoreCanvas;
    public GameObject Game;
    public GameObject playMenu;
    public GameObject restartGame;

   public Button replayButton;


    void Update()
    {
        if (GameManager.singleton.nextLevelCalled == true)
        {
            StartCoroutine("StageCountUI");
        }

        txtBest.text = "Best: " + GameManager.singleton.best;
        txtScore.text = "" + GameManager.singleton.score;
        
        
        Replay.SetActive(GameManager.singleton.replayButtonActivation);
        txtLives.text = "Replay: " + GameManager.singleton.livesCount;

        if (GameManager.singleton.livesCount <= 0)
        {
            if (GameManager.singleton.replayButtonActivation)
            {
                replayButton.interactable = false;
                Replay.SetActive(true);
                txtLives.text = "Replay: " + GameManager.singleton.livesCount;
                restartGame.SetActive(true);
            }
            else
            {
                Replay.SetActive(false);
                restartGame.SetActive(false);
            }
        }
    }

    public IEnumerator StageCountUI()
    {
        scoreCanvas.SetActive(false);
        Game.SetActive(false);

        stageUI.SetActive(true);
        int stage = GameManager.singleton.currentStage+1;
        stageCount.text = "Stage: " + stage;

        yield return new WaitForSeconds(2f);
        stageUI.SetActive(false);
        GameManager.singleton.nextLevelCalled = false;
        scoreCanvas.SetActive(true);
        Game.SetActive(true);
    }


    public void PlayButton()
    {
        Game.SetActive(true);
        scoreCanvas.SetActive(true);
        
        playMenu.SetActive(false);
    }

    private void Awake()
    {
        Game.SetActive(false);
        scoreCanvas.SetActive(false);
        stageUI.SetActive(false);
        stageUI.SetActive(false);
        restartGame.SetActive(false);

        playMenu.SetActive(true);

        replayButton.interactable = true;
    }


}
