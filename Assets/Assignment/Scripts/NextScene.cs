using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class NextScene : MonoBehaviour
{ 
   public void LoadNextScene()
   {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
    SceneManager.LoadScene(nextSceneIndex);
   }
}

