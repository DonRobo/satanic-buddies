using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{

    public Vector3 direction;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Collider>().gameObject.transform.Translate(direction * 0.03f);

        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        GameObject.Destroy(this);
    }
}
