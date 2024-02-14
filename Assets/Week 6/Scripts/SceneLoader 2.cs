using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader2 : MonoBehaviour
{
    public SceneLoader sceneLoader;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            sceneLoader.LoadNextScene();
        }
    }
}
