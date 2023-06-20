using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    bool Started;
    Rigidbody rigidBody;
    // Start is called before the first frame update
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Started = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rigidBody.velocity = new Vector3(speed, 0, 0);
                Started = true;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            SwitchWay();
        }
    }

    void SwitchWay()
    {
        if (rigidBody.velocity.x > 0)
        {
            rigidBody.velocity = new Vector3(0,0,speed);
        }else if (rigidBody.velocity.z > 0)
        {
            rigidBody.velocity = new Vector3(speed, 0, 0);
        }
    }
}
