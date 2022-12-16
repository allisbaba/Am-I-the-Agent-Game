using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class over : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("TheEdgeCorpScene");
    }

    public void Quit_App()
    {
        Application.Quit();
    }
}
