using UnityEngine;
using System.Collections;

public class Levelspawner : MonoBehaviour {
    
    public GameObject levelPlane;
    public GameObject player;
    public int lastTile = -1;
    private readonly int tileSize = 100;

    void Start () {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }
    }

    void Update () {
        if (player.transform.position.x > lastTile * tileSize - tileSize / 2)
        {
            GameObject.Instantiate(levelPlane, new Vector3( lastTile * tileSize+tileSize/2,0,0), Quaternion.identity);
            lastTile++;
        }
	}
}
