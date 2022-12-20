using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Restaurant");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
