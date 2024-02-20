using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class sceneManager : MonoBehaviour
{
    public Button nextSceneButton;
    public Button restartGameButton;

    // Start is called before the first frame update
    void Start()
    {
        nextSceneButton.onClick.AddListener(LoadNextScene);
        restartGameButton.onClick.AddListener(LoadNextScene2);
    }

    private void LoadNextScene()
    {
        {
            SceneManager.LoadScene("Gameplay");
        }
    }

    private void LoadNextScene2()
    {
        {
            SceneManager.LoadScene("Start page");
        }
    }
    

}
