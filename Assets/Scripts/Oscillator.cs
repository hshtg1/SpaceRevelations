using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;

    Vector3 startingPosition;
    const float tau = 2 * Mathf.PI;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) return;
        float cycles = Time.time/ period;
        float rawSineWave = Mathf.Sin(tau*cycles); //now it goes through -1 to 1
        movementFactor = (rawSineWave + 1f) / 2f; //now it goes through 0 to 1
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
