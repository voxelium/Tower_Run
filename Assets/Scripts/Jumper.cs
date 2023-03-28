using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] float _jumpForce;
    private Rigidbody _rigidbody;
    private bool isGrounded;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        if (isGrounded == true && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
            isGrounded = false;
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Road road))
        {
            isGrounded = true;
        }
      
    }

}
