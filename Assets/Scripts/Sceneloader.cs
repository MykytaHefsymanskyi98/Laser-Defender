using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sceneloader : MonoBehaviour
{
    float gameSpeed = 1f;
    bool gameOnPause = false;
    [SerializeField] GameObject pauseCanvas;
    public void LoadGameScene()
    {
        Cursor.visible = false;
        Time.timeScale = gameSpeed;
        SceneManager.LoadScene(1);
    }

    public void LoadLastScene()
    {
        StartCoroutine("LoadLastSceneCoroutine");
       
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        if(FindObjectOfType<GameSession>())
        {
            Destroy(FindObjectOfType<GameSession>());
        }
        Cursor.visible = true;
        SceneManager.LoadScene(0);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Pause();
    }
    IEnumerator LoadLastSceneCoroutine()
    {
        yield return new WaitForSeconds(3);
        Cursor.visible = true;
        SceneManager.LoadScene(2);
    }

    public void PlayAgain()
    {
        Cursor.visible = false;
        SceneManager.LoadScene(1);
        FindObjectOfType<GameSession>().DestroyScore();
    }


    public void ResumeGame()
    {
        Time.timeScale = gameSpeed;
        pauseCanvas.gameObject.SetActive(false);
        gameOnPause = false;
        Cursor.visible = false;
    }

    void Pause()
    {
        if (Input.GetKeyDown("escape") && SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 2 && !gameOnPause)
        {
            Time.timeScale = 0f;
            pauseCanvas.gameObject.SetActive(true);
            gameOnPause = true;
            Cursor.visible = true;
        }
        else if(Input.GetKeyDown("escape") && gameOnPause)
        {
            Time.timeScale = gameSpeed;
            pauseCanvas.gameObject.SetActive(false);
            gameOnPause = false;
            Cursor.visible = false;
        }
    }
}
