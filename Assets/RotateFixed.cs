using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFixed : MonoBehaviour
{

    Rigidbody rb;
    public float speed;
    enum RotateDirection {Left, Right} ;
    [SerializeField]
    RotateDirection rotateDirection; 

    private void Start()
    {

        rb = GetComponent<Rigidbody>();

    }
    void FixedUpdate()
    {
        Vector3 position = rb.position;

        if (rotateDirection == RotateDirection.Left)
            
            rb.position -= new Vector3(1 * Time.fixedDeltaTime * speed, 0 , 0 );

        else

            rb.position -= new Vector3(-1 * Time.fixedDeltaTime * speed, 0, 0);

        rb.MovePosition(position);
    }
}
