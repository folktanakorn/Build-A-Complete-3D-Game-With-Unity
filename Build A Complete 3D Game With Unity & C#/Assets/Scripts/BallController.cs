using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    bool Started;

    bool GameOver = false;
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

        Debug.DrawRay(transform.position, Vector3.down, Color.red);
        if(!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            GameOver = true;
            rigidBody.velocity = new Vector3(0, -25f, 0);
        }

        if (Input.GetMouseButtonDown(0) && !GameOver)
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
