using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    // ----- VARIABLES ----- //
    public string sceneName;
    // ----- VARIABLES ------ // 

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
