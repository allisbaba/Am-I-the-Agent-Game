using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{
    public GameObject info_pnl;
    public GameObject options_pnl;
    public AudioSource theme;
    public GameObject giris;
    public GameObject start;
    public GameObject btn;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Play()
    {
        
        start.SetActive(false);
        theme.Stop();
        giris.SetActive(true);
        Invoke("Call_btn", 41);
    }

    public void Info()
    {
        info_pnl.SetActive(true);
    }
    public void inInfo()
    {
        info_pnl.SetActive(false);
    }
    public void Options()
    {
        options_pnl.SetActive(true);
    }
    public void Ex_Opt()
    {
        options_pnl.SetActive(false);
    }

    public void SetFullScreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }
    public void SetMusic(bool isMusic)
    {
        theme.mute = !isMusic;
    }
    public void Quit()
    {
       
        Application.Quit();
    }

    public void Call_btn()
    {
        btn.SetActive(true);
    }
    public void Button()
    {
        SceneManager.LoadScene("TheEdgeCorpScene");
        
    }
}
