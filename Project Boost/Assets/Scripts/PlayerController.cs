using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] float thrustForceVariable = 2.5f;
    [SerializeField] float rotationSensitivity = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessRotation();
        ProcessThrust();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(0, thrustForceVariable * Time.deltaTime, 0);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            // left 
            Rotate(rotationSensitivity);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // right 
            Rotate(-rotationSensitivity);
        }
    }

    public void Rotate(float frameRotation)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * frameRotation * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
