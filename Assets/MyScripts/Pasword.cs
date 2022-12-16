using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using UnityEngine.UI;

public class Pasword : MonoBehaviour
{
    [SerializeField] private Text text;
    public GameObject safe;
    public GameObject player;
    public GameObject canvas;
    public Text message;
    private InventoryPanelController InventoryPanelController;

    void Start()
    {
        InventoryPanelController = player.GetComponent<InventoryPanelController>();
    }


    // Update is called once per frame
    void Update()
    {
        if (text.text.Length <= 3)
        {
            if (Input.GetKeyDown(KeyCode.Backspace) && text.text != null )
            {
                text.text = text.text.Remove(text.text.Length - 1);
            }
            else if (Input.inputString != null)
            {
                text.text +=Input.inputString.ToString();
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                text.text += " ";
            }

            
        }
        else if (text.text.ToLower().Equals("Edge".ToLower()))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            InventoryPanelController.Source.PlayOneShot(InventoryPanelController.Clips[5]);
            InventoryPanelController.InfoCount++;
            message.text = "- You collected all files. You can leave. -";
            safe.gameObject.tag = "Untagged";
            Time.timeScale = 1f;
            gameObject.SetActive(false);
                
        }
        else
        {
            InventoryPanelController.Source.PlayOneShot(InventoryPanelController.Clips[6]);
            text.text = "";
        }
       
    
  
    }

    public void CloseCanvas()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        canvas.SetActive(false);
        
    }

}