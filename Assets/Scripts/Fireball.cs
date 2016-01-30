using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour
{

    public GameObject explosionPrefab;
    public Vector3 direction;
    public float speed;
    public float damage = 40;
    public float force = 1000;
    public float range = 3;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (direction.x > 0)
        {
            transform.FindChild("FireballRight").gameObject.SetActive(true);
            transform.FindChild("FireballLeft").gameObject.SetActive(false);
        }
        else
        {
            transform.FindChild("FireballRight").gameObject.SetActive(false);
            transform.FindChild("FireballLeft").gameObject.SetActive(true);
        }

        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerController>()!= null)
        {
            return;
        }

        GameObject explosion = GameObject.Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
        explosion.GetComponent<Explosion>().force = force;
        explosion.GetComponent<Explosion>().range = range;
        explosion.GetComponent<Explosion>().damage = damage;
        Destroy(this.gameObject);
    }

}
