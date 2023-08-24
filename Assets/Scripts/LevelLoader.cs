//This script very simply loads the first level, and is only used from the main menu when pressing "Start"
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevel1() //loads the first level
    {
        SceneManager.LoadScene("Scene1");
    }
    public void GameOver() //loads the first level
    {
        SceneManager.LoadScene("GameOver");
    }
}
