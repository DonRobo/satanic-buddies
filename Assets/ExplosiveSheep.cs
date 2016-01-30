using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExplosiveSheep : MonoBehaviour
{

    public GameObject explosionPrefab;
    public float fuse = 1;
    private bool activated = false;
    public float damage = 90;
    public float force = 1;
    public float range = 8;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            fuse -= Time.deltaTime;

            if (fuse < 0)
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
                GameObject.Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
        else {
            Enemy[] enemies = FindObjectsOfType<Enemy>();
            foreach (Enemy enemy in enemies)
            {
                if ((enemy.transform.position - transform.position).sqrMagnitude < range * range)
                {
                    activated = true;
                    break;
                }
            }
        }
    }
}

