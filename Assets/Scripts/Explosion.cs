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
        IList<Enemy> hitEnemies = new List<Enemy>();
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
