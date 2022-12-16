using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectToPlayer : MonoBehaviour
{
    #region Variables

    private RaycastHit hit;
    [SerializeField] private LineRenderer lineRn;
    [SerializeField] private Camera cam;
    [SerializeField] private float maxDistance = 10f;

    #endregion
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        lineRn.SetPosition(0,cam.transform.position);
        lineRn.SetPosition(1,cam.transform.position+new Vector3(-6,0,0));
        
        if (Physics.Raycast(cam.transform.position,cam.transform.forward, out hit, maxDistance))
        {
            lineRn.enabled = true;
           
            Debug.Log(hit.transform.name);
        }
        else
        {
            lineRn.enabled = false;
        }
        Debug.DrawRay(cam.transform.position,cam.transform.position+cam.transform.forward,Color.black);
        
    }
}
