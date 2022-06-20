using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadScene(string input)
    {
        SceneManager.LoadScene(input);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
