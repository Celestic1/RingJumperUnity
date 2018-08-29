using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] obstacles;
    public Transform[] obstaclePos;

    public Transform spawn;

	// Use this for initialization
	void Start () {
        SpawnNewObstacles();
	}
	
    void SpawnNewObstacles()
    {
        for (int i = 0; i < 5; i++)
        {
            int randomObstacle = Random.Range(0, obstacles.Length);

            Instantiate(obstacles[randomObstacle], obstaclePos[i].position,
                Quaternion.identity);
        }
       
    }

	void ChangePos()
    {
        Vector3 temp = transform.position;
        temp.y = 36 / 2;
        transform.position = temp;

        Vector3 spawnPos = spawn.position;
        spawnPos.y += 36;
        spawn.position = spawnPos;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            ChangePos();
            SpawnNewObstacles();
        }
    }
}
