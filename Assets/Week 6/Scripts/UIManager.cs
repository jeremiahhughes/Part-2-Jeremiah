using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Button nextSceneButton;
    public int width;
    public int height;

    public void Start()
    {
        nextSceneButton.onClick.AddListener(LoadNextScene);
    }

    private void LoadNextScene()
    { 

        {
            SceneManager.LoadScene("Week 5");
        }
    }


    public void SetWidth(int newWidth){
        width = newWidth;
    }

    public void SetHeight(int newHeight){
        height = newHeight;
    }
    public void Setres(){
        Screen.SetResolution(width, height, false);
    }
}

