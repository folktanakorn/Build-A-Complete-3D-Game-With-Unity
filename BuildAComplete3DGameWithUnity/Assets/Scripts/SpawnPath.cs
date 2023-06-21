using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPath : MonoBehaviour
{
    public GameObject PathPrefabs;
    public GameObject DiamonsPrefabs;
    Vector3 lastPosition;
    float size;
    public bool GameOver;
    // Start is called before the first frame update
    void Start()
    {
        lastPosition = PathPrefabs.transform.position;
        size = PathPrefabs.transform.localScale.x;
        for (int i = 0; i < 20; i++)
        {
            SpawnRandom();
        }

        InvokeRepeating("SpawnRandom",2f,0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver)
        {
            CancelInvoke("SpawnRandom");
        }
    }

    void SpawnRandom()
    {
        int RandomNumber = Random.Range(0, 6);
        if (RandomNumber > 3)
        {
            SpawnX();
        }
        else if(RandomNumber <= 3){
            SpawnZ();
        }
    }

     
    void SpawnX()
    {
        Vector3 pos = lastPosition;
        pos.x += size;
        lastPosition = pos;
        Instantiate(PathPrefabs, pos, Quaternion.identity);

        int RandomDiamons = Random.Range(0,4);
        if (RandomDiamons < 2)
        {
            Instantiate(DiamonsPrefabs,new Vector3(pos.x,pos.y + 1.5f ,pos.z), DiamonsPrefabs.transform.rotation);
        }
    }
    void SpawnZ()
    {
        Vector3 pos = lastPosition;
        pos.z += size;
        lastPosition = pos;
        Instantiate(PathPrefabs, pos, Quaternion.identity);

        int RandomDiamons = Random.Range(0, 4);
        if (RandomDiamons < 2)
        {
            Instantiate(DiamonsPrefabs, new Vector3(pos.x, pos.y + 1.5f, pos.z), DiamonsPrefabs.transform.rotation);
        }

    }

  
}
