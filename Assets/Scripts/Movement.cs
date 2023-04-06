using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

public class Movement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float thrustingForceRotation = 200f;
    
    [SerializeField] private float thrustingForceUP = 800f;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       ProcessThrust();
       ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddRelativeForce(0,thrustingForceUP * Time.deltaTime,0);
        }
    }

    void ProcessRotation()
        {
            if (Input.GetKey(KeyCode.D))
            {
                ApplyRotation(-thrustingForceRotation);
            }

            else if (Input.GetKey(KeyCode.A))
            {
                ApplyRotation(thrustingForceRotation);
            }
        }

    private void ApplyRotation(float rotationThisFrame)
    {
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
    }
}
