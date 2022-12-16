using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightMove : MonoBehaviour
{
    private InventoryPanelController InventoryPanelController;
    public GameObject player;
    public float speed = 1;
    public GameObject NightCamera;
    //public LightScript Light;
    public GameObject people;
    public bool IsNight = false;
    

    private void Start()
    {
        InventoryPanelController = player.GetComponent<InventoryPanelController>();

    }
    private void Update()
    {
        if (!IsNight && InventoryPanelController.InfoCount == 7)
        {
            
           
            people.SetActive(true);
            NightCamera.SetActive(true);
            moving();
            StartCoroutine(nameof(StartDelay));
            
        }


    }

    void moving()
    {
        transform.Translate(Time.deltaTime * speed * -Vector3.forward);

    }

    IEnumerator StartDelay()
    {
        
        yield return new WaitForSeconds(3f);
        IsNight = true;
        NightCamera.SetActive(false);
        GameObject[] peopletagged = GameObject.FindGameObjectsWithTag("People");
        foreach (GameObject persontagged in peopletagged)
        {
            Destroy(persontagged);
        }

        

    }
}