using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cable : MonoBehaviour
{


    public GameObject red;
    public GameObject blue;
    public GameObject green;
    public GameObject yellow;
    public GameObject pnl;
    public GameObject task;

    public GameObject _switch;

    private int cable_down;

    public GameObject player;
    private InventoryPanelController InventoryPanelController;

    public bool isSwitched = false;

    void Start()
    {
        InventoryPanelController = player.GetComponent<InventoryPanelController>();
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            red.SetActive(false);
            cable_down++;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            blue.SetActive(false);
            cable_down++;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            green.SetActive(false);
            cable_down++;
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            yellow.SetActive(false);
            cable_down++;
        }
        if (cable_down == 4)
        {
            InventoryPanelController.Source.PlayOneShot(InventoryPanelController.Clips[4]);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
            isSwitched = true;

            _switch.transform.gameObject.tag = "Untagged";
            task.SetActive(false);
           

        }

        }

    }