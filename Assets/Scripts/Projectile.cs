using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public float lifetime = 2;
    private float age = 0;
    public float damage = 10;
    public float speed = 30;
    public Vector3 direction;

    private Transform sprite;

    private Animator animator;


    // Use this for initialization
    void Start()
    {
        direction = direction.normalized * speed;
        sprite = transform.FindChild("Sprite");

        animator = GetComponentInChildren<Animator>();
        animator.speed = 1;
        if (direction.x < 0)
        {
            sprite.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }

        //sprite.transform.rotation = (Quaternion.FromToRotation(Vector3.right, direction));
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
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            return;
        }
        if (other.gameObject.GetComponent<Enemy>() != null && other.gameObject.GetComponent<Rigidbody>() != null)
        {
            other.GetComponent<Enemy>().Damage(damage);
            other.GetComponent<Rigidbody>().AddForce(direction.normalized * 200);
        }
        if (other.gameObject.GetComponent<DestructibleObstacle>() != null)
        {
            other.GetComponent<DestructibleObstacle>().Damage(damage * 5);
        }
        if (other.gameObject.GetComponent<PlayerController>() == null)
        {
            GameObject.Destroy(this.gameObject);
        }
        else
        {
            Debug.Log(other.gameObject.GetComponent<PlayerController>());
        }
    }
}
