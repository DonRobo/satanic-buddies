using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExplosiveSheep : MonoBehaviour
{

    public GameObject explosionPrefab;
    public float fuse = 1;
    private bool activated = false;
    public float damage = 90;
    public float force = 1000;
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
                GameObject explosion = GameObject.Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
                explosion.GetComponent<Explosion>().force = force;
                explosion.GetComponent<Explosion>().range = range;
                explosion.GetComponent<Explosion>().damage = damage;
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

