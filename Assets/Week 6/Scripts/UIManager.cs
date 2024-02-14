using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Button nextSceneButton;
    public Button resolution16_9Button;
    public Button fullHDButton;

    public void Start()
    {
        nextSceneButton.onClick.AddListener(LoadNextScene);
        resolution16_9Button.onClick.AddListener(SetResolution16_9);
        fullHDButton.onClick.AddListener(SetResolutionFullHD);
    }

    private void LoadNextScene()
    { 

        {
            SceneManager.LoadScene("Week 5");
        }
    }


    public void SetResolution16_9()
    {
        Screen.SetResolution(1600, 900, FullScreenMode.Windowed);
    }

    public void SetResolutionFullHD()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
    }
}
