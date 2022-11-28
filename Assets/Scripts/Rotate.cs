 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform cameraTransform;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Vector3.ProjectOnPlane(cameraTransform.position+transform.position, transform.root.transform.up));
        transform.Rotate(-90, 90, 90);
        //transform.rotation.SetLookRotation(Vector3.ProjectOnPlane(cameraTransform.position + transform.position, transform.root.transform.forward));
    }
}
