using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayMaze()
    {
        SceneManager.LoadScene("MazeScene");
    }
    public void QuitMaze()
    {
        UnityEngine.Debug.Log("Quit Game");
        Application.Quit();
    }
}
