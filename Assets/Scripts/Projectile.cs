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
      
        if (other.GetComponent<PlayerController>() != null)
        {
            return;
        }
        Debug.Log("HIT TRIGGER");
        if (other.GetComponent<Enemy>() != null && other.GetComponent<Rigidbody>() != null)
        {
            Debug.Log("HIT ENEMY");
            other.GetComponent<Enemy>().Damage(damage);
            other.GetComponent<Rigidbody>().AddForce(direction.normalized * 200);
        }
        if (other.gameObject.GetComponent<DestructibleObstacle>() != null)
        {
            Debug.Log("HIT OBSTACLE");
            other.GetComponent<DestructibleObstacle>().Damage(damage * 10);
        }
        if (other.GetComponent<PlayerController>() == null)
        {
            GameObject.Destroy(other.gameObject);
        }
    }
}
