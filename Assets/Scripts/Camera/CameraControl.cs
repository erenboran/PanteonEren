using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public GameObject target;
    [SerializeField] private Vector3 offset;


    void LateUpdate()
    {

        this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position + offset, Time.smoothDeltaTime + 1);
    }
}
 