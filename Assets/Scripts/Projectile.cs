using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{

    public float lifetime = 2;
    private float age = 0;
    public float damage = 10;
    public float speed = 30;
    public Vector3 direction;

    // Use this for initialization
    void Start()
    {
        direction = direction.normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        age += Time.deltaTime;
        if (age > lifetime)
        {
            Destroy(this.gameObject);
        }
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() != null && other.GetComponent<Rigidbody>() != null)
        {
            other.GetComponent<Enemy>().Damage(damage);
            other.GetComponent<Rigidbody>().AddForce(direction.normalized * 200);
        }
        if (other.GetComponent<PlayerController>() == null)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
