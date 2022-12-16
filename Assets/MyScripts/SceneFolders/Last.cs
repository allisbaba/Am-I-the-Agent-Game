using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Last : MonoBehaviour
{
    public AudioSource atom;
    public void Atom()
    {
        atom.Play();
    }
    public void Final()
    {
        Application.Quit();
    }
}
