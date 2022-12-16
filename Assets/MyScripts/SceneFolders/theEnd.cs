using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theEnd : MonoBehaviour
{
    public GameObject text_one;
    public GameObject text_two;
    public GameObject boss_two;
    public GameObject boss_three;
    public AudioSource message;
    public GameObject button;
    public GameObject boss;
    
   
    void Start()
    {
        Invoke("textOne", 7);
        Invoke("textTwo", 11);
        Invoke("bossTwo", 8);
        Invoke("bossThree", 13.5f);
        Invoke("Btn", 15);
        
    }

    public void textOne()
    {
        text_one.SetActive(true);
        message.Play();
    }
    public void textTwo()
    {
        text_two.SetActive(true);
        message.Play();
    }
    public void bossTwo()
    {
        boss_two.SetActive(true);
    }
    public void bossThree()
    {
        boss_three.SetActive(true);
    }
    public void Btn()
    {
        button.SetActive(true);
    }
    public void Final()
    {
        boss.SetActive(true);
    }
    
    


    // Update is called once per frame
    void Update()
    {
        
    }
}
