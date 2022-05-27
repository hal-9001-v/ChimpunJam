using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    const int EndSceneIndex = 3;

    public void End()
    {
        SceneManager.LoadScene(EndSceneIndex);
    }
}
