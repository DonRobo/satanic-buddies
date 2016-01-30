using UnityEngine;
using System.Collections;
using System;

public class Levelspawner : MonoBehaviour
{

    public GameObject levelPlane;
    public GameObject player;
    public int lastTile = -1;

    private readonly int tileSize = 100;

    private GameObject[] obstacleLib;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }
        obstacleLib = Resources.LoadAll<GameObject>("Obstacles");
    }

    void Update()
    {
        if (player.transform.position.x > lastTile * tileSize - tileSize / 2)
        {
            GameObject.Instantiate(levelPlane, new Vector3(lastTile * tileSize + tileSize / 2, 0, 0), Quaternion.identity);
            AddRandomObstacles();
            if (player.transform.position.y < 0) {
                player.transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z);
            }
            lastTile++;
        }
    }

    private void AddRandomObstacles()
    {
        float minX = lastTile * tileSize;
        float minY = -10;
        float maxX = minX + tileSize;
        float maxY = 15;

        for (int i = 0; i < 30; i++)
        {
            GameObject obstacle = obstacleLib[UnityEngine.Random.Range(0, obstacleLib.Length)];
            //Debug.Log(new Vector3(UnityEngine.Random.Range(minX, maxX), 0, UnityEngine.Random.Range(minY, maxY)));
            GameObject.Instantiate(obstacle, new Vector3(UnityEngine.Random.Range(minX, maxX), 0, UnityEngine.Random.Range(minY, maxY)), Quaternion.identity);
        }
    }
}
