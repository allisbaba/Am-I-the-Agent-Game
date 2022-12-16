using System.Collections;
using UnityEngine;
using UnityEngine.UI;
// Type Writer Script, Author : witnn .

[RequireComponent(typeof(AudioSource))]
public class message : MonoBehaviour
{
    public float delay = 0.1f;
    public AudioClip TypeSound;
    [Multiline]
    public string yazi;
    //public GameObject btn;

    AudioSource audSrc;
    Text thisText;

    private void Start()
    {
        audSrc = GetComponent<AudioSource>();
        thisText = GetComponent<Text>();

        StartCoroutine(TypeWrite());
    }

    IEnumerator TypeWrite()
    {
        foreach (char i in yazi)
        {
            thisText.text += i.ToString();

            //audSrc.pitch = Random.Range(0.1f, 1.2f);
            audSrc.PlayScheduled(0.8);

            if (i.ToString() == ".") { yield return new WaitForSeconds(1);
                //audSrc.Stop();
            }
            else if (i.ToString() == "!") { yield return new WaitForSeconds(1);
                //audSrc.Stop();
            }
            else if (i.ToString() == "?") { yield return new WaitForSeconds(1);
                //audSrc.Stop();
            }
            /*else if (i.ToString() == "...")
            {
                btn.SetActive(true);
            }*/
            else { yield return new WaitForSeconds(delay); }
        }
    }
}
