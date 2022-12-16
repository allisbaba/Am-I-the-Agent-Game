using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Move : MonoBehaviour
{
    #region Variables

    [SerializeField] private float horizantalInput;
    [SerializeField] private float speed = 20f;
    public Rigidbody securityRb;

    #endregion
    void Update()
    {
        horizantalInput = Input.GetAxis("Horizontal") * (Time.deltaTime * speed);
        securityRb.AddForce(horizantalInput*Vector3.left);
    }
}
