using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    #region Variables

    public RaycastHit hit;
    private Ray ray;
    [SerializeField] private float maxDistance = 20f;
    [SerializeField] private Camera cam;

    #endregion
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, maxDistance))
        {
            //Debug.Log("." + hit.transform.name);
        }

        Debug.DrawLine(cam.transform.position, cam.transform.position + cam.transform.forward, Color.black);
    }
}
