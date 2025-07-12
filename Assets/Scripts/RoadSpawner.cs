using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawnScript : MonoBehaviour
{
    public GameObject obstacle;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            SpawnObstacle();
            timer = 0;
        }

    }

    void SpawnObstacle()
    {
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(obstacle, new Vector3(transform.position.x, highestPoint, 0), transform.rotation);

    }
}