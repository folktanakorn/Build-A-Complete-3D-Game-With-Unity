using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject Partical;
    [SerializeField]
    private float speed;

    bool Started;

    bool GameOver;
    Rigidbody rigidBody;
    // Start is called before the first frame update
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Started = false;
        GameOver = false;
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
                GameManager.instance.GameStart();
            }
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red);
        if(!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            GameOver = true;
            Camera.main.GetComponent<CameraController>().GameOver = true;
            rigidBody.velocity = new Vector3(0, -25f, 0);
            GameManager.instance.GameOver();
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Diamons")
        {
            GameObject Paticaltemp = Instantiate(Partical, other.gameObject.transform.position, Partical.transform.rotation) as GameObject;
            Destroy(other.gameObject);
            Destroy(Paticaltemp,3f);
        }
    }
}
