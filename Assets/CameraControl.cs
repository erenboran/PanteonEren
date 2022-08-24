using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public GameObject target;
    [SerializeField] private Vector3 offset;
   // public GameObject fnishCameraPos;


    void LateUpdate()
    {
        //transform.position = target.position + offset;

        //if (GameManager.Instance.levelFnish)
        //{
        //    transform.position = fnishCameraPos.transform.position;
        //    offset = new Vector3(0, 0, 0);
        //}
        this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position + offset, Time.deltaTime);
    }
}
 