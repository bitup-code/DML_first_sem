using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadLvl(int numScene)
    {

        SceneManager.LoadScene(numScene);
    }

    public void Win(int numScene)
    {
        SceneManager.LoadScene(2);
    }
    public void Lose(int numScene)
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
    
}
