using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed1;
    public float rotationSpeed2;
    public float rotationSpeed3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed1 * Time.deltaTime, rotationSpeed2 * Time.deltaTime, rotationSpeed3 * Time.deltaTime, Space.World);
    }
}
