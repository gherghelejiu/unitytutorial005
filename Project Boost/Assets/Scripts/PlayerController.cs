using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float thrustForceVariable = 2.5f;
    [SerializeField] float rotationSensitivity = 2.5f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem leftJet;
    [SerializeField] ParticleSystem rightJet;
    [SerializeField] ParticleSystem mainJet;

    Rigidbody rb;
    AudioSource audioSource;


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
                audioSource.PlayOneShot(mainEngine);
                mainJet.Play();
            }
            rb.AddRelativeForce(0, thrustForceVariable * Time.deltaTime, 0);
        } else
        {
            if (audioSource.isPlaying)
            {
                mainJet.Stop();
                audioSource.Stop();
            }
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            // left 
            if (!rightJet.isPlaying)
            {
                rightJet.Play();
            }
            Rotate(rotationSensitivity);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // right 
            if (!leftJet.isPlaying)
            {
                leftJet.Play();
            }
            Rotate(-rotationSensitivity);
        }
        else
        {
            rightJet.Stop();
            leftJet.Stop();
        }
    }

    public void Rotate(float frameRotation)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * frameRotation * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
