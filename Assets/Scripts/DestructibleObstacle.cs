using UnityEngine;
using System.Collections;

public class DestructibleObstacle : MonoBehaviour
{

    public GameObject explosionPrefab;
    private GameObject player;
    private float health = 100;

    // Use this for initialization
    void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }
    }

    void Update()
    {

    }

    public void Damage(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position + new Vector3(0, 1, 1), Quaternion.identity) as GameObject;
            explosion.GetComponent<Explosion>().force = 3000;
            explosion.GetComponent<Explosion>().range = 10;
            explosion.GetComponent<Explosion>().damage = 5;

            Destroy(this.gameObject);
        }
    }

}
