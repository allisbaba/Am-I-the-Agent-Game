using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class admin : MonoBehaviour
{
    public GameObject canvas;
    public GameObject ProjectionImage;
    int insert_part = 0;
    int total_puzzle = 16;
    public GameObject projection;

    public GameObject player;
    private InventoryPanelController InventoryPanelController;

    void Start()
    {
        InventoryPanelController = player.GetComponent<InventoryPanelController>();
    }
   

    public void CloseCanvas()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        canvas.SetActive(false);
        Time.timeScale = 1f;
    }

    public void number_increase()
    {
        insert_part++;
        if (insert_part == total_puzzle)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
            ProjectionImage.SetActive(true);
            projection.tag = "Untagged";
            canvas.SetActive(false);
            InventoryPanelController.Source.PlayOneShot(InventoryPanelController.Clips[7]);
        }
    }
    void Update()
    {
        
    }
}
