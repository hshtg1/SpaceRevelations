using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float thrustSpeed = 100f;
    [SerializeField] float leftRotSpeed = 100f;
    [SerializeField] float rightRotSpeed = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainThruster, leftThruster, rightThruster;

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
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ThrustRight();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ThrustLeft();
        }
        else
        {
            StopSideThrust();
        }
    }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * Time.deltaTime * thrustSpeed);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (mainThruster.isPlaying == false) mainThruster.Play();
    }
    void StopThrusting()
    {
        audioSource.Stop();
        mainThruster.Stop();
    }

    void ThrustRight()
    {
        ApplyRotation(leftRotSpeed);
        if (rightThruster.isPlaying == false) rightThruster.Play();
    }

    void ThrustLeft()
    {
        ApplyRotation(-rightRotSpeed);
        if (leftThruster.isPlaying == false) leftThruster.Play();
    }

    void StopSideThrust()
    {
        leftThruster.Stop();
        rightThruster.Stop();
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
        rb.freezeRotation = false;
    }
}
