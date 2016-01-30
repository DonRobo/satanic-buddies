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

    public float movementSpeed = 5.0f;
    public int changeFrame = 50;

    private Vector3 movementDirection;
    private int time;

    // Use this for initialization
    void Start()
    {
        time = Time.frameCount;
        
        float randomAngle = UnityEngine.Random.Range(0.0f, 2 * Mathf.PI);
        movementDirection = new Vector3(Mathf.Sin(randomAngle), 0.0f, Mathf.Cos(randomAngle));
    }

    // Update is called once per frame
    void Update()
    {
        time++;
        if (time % changeFrame == 0)
        {
            float randomAngle = UnityEngine.Random.Range(0.0f, 2 * Mathf.PI);
            movementDirection = new Vector3(Mathf.Sin(randomAngle), 0.0f, Mathf.Cos(randomAngle)) ;
        }                                                                                              


        transform.Translate(movementDirection * Time.deltaTime * movementSpeed) ;

        if (activated && fuse > 0)
        {
            GetComponent<AudioSource>().Play();
            fuse -= Time.deltaTime;

            if (fuse < 0)
            {
                GameObject explosion = GameObject.Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
                explosion.GetComponent<Explosion>().force = force;
                explosion.GetComponent<Explosion>().range = range;
                explosion.GetComponent<Explosion>().damage = damage;

                GetComponentInChildren<SpriteRenderer>().enabled = false;

                Destroy(this.gameObject, 1);
            }
        }
        else
        {
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

