using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManagement : MonoBehaviour
{

    private bool gamePaused;
    // Start is called before the first frame update
    void Start()
    {
        gamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainMenu(int mainMenuIdx = 0)
    {
        SceneManager.LoadScene(mainMenuIdx);
    }

    //I assume 0 is the main menu
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }

    //load user defined lv
    public void LoadLevelOf(int buildIdx)
    {
        SceneManager.LoadScene(buildIdx);
    }

    //restart current lv
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //load next lv (in the build)
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //pause the game
    public void PauseGame()
    {
        //freeze time scale
        PauseTimeScale();
        gamePaused = true;
        //FIXME: maybe show the pause window ? or handle by another code
    }

    //resume the game
    public void ResumeGame()
    {
        //unfreeze time scale
        ResetTimeScale();
        gamePaused = false;
    }


    //check if the game is paused
    public bool IsGamePaused()
    {
        return gamePaused;
    }


    public void QuitGame()
    {
        Application.Quit();
    }




    //if you win or lose, we can use it to pause the game
    public void PauseTimeScale()
    {
        Time.timeScale = 0f;
    }

    public void ResetTimeScale()
    {
        Time.timeScale = 1f;
    }












}
