using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{

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
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null)
        {
            other.GetComponent<Rigidbody>().AddForce(direction.normalized * 3);
            GameObject.Destroy(this.gameObject);
        }
    }
}
