using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private float horizantalInput;
    private float verticalInput;
    private float speed = 20f;
    public float horSpeed = 100f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Mouse Y") * (Time.deltaTime * speed);
        horizantalInput = Input.GetAxis("Mouse X") * (Time.deltaTime * horSpeed);
        //transform.Translate(Vector3.forward * verticalInput);
        transform.Rotate(Vector3.up * horizantalInput);
        transform.Rotate(Vector3.left *verticalInput);

    }
}