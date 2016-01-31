using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Explosion : MonoBehaviour {

    public float lifetime;
    private float age;
    public float range;
    public float force;
    public float damage;

    void Start()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            Vector3 dist = (enemy.transform.position - transform.position);
            if (dist.sqrMagnitude < range * range)
            {
                enemy.Damage(damage);
                enemy.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, range);
            }
        }
        PlayerController[] players = FindObjectsOfType<PlayerController>();
        foreach (PlayerController player in players)
        {
            Vector3 dist = (player.transform.position - transform.position);
            if (dist.sqrMagnitude < range * range)
            {
                player.Damage(damage);
            }
        }
        DestructibleObstacle[] obstacles = FindObjectsOfType<DestructibleObstacle>();
        foreach (DestructibleObstacle obstacle in obstacles)
        {
            Vector3 dist = (obstacle.transform.position - transform.position);
            if (dist.sqrMagnitude < range * range)
            {
                obstacle.Damage(damage);
            }
        }
    }

    // Update is called once per frame
    void Update () {
        age += Time.deltaTime;
        if (age > lifetime)
        {
            Destroy(this.gameObject);
        }
	}
}
