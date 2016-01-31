using UnityEngine;
using System.Collections;

public class DestructibleObstacle : MonoBehaviour
{

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
            Destroy(this.gameObject);
        }
    }

}
