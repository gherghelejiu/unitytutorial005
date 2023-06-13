using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] float thrustForceVariable = 2.5f;
    [SerializeField] float rotationSensitivity = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
            if (audioSource.isPlaying)
            {
                // 
            } else
            {
                audioSource.Play();
            }
            rb.AddRelativeForce(0, thrustForceVariable * Time.deltaTime, 0);
        } else
        {
            if (audioSource.isPlaying)
            {
                //
                audioSource.Stop();
            }
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
