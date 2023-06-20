using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPath : MonoBehaviour
{
    public GameObject PathPrefabs;
    Vector3 lastPosition;
    float size;
    // Start is called before the first frame update
    void Start()
    {
        lastPosition = PathPrefabs.transform.position;
        size = PathPrefabs.transform.localScale.x;
        for (int i = 0; i < 5 ;i++)
        {
            SpawnZ();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnX()
    {
        Vector3 pos = lastPosition;
        pos.x += size;
        lastPosition = pos;
        Instantiate(PathPrefabs, pos, Quaternion.identity);
    }
    void SpawnZ()
    {
        Vector3 pos = lastPosition;
        pos.z += size;
        lastPosition = pos;
        Instantiate(PathPrefabs, pos, Quaternion.identity);

    }
}
