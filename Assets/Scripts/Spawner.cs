using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    public GameObject prefab;
    public float interval = 1;

    private float lastSpawn = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lastSpawn += Time.deltaTime;
        if (lastSpawn > interval)
        {
            lastSpawn = 0;
            GameObject.Instantiate(prefab, transform.position + new Vector3(0, 0, Random.Range(-20, 20)), Quaternion.identity);
        }
    }
}
