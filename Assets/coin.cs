using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    float rotationSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);*/
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
