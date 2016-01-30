using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public float speed = 10;
    private GameObject player;
    private float health = 100;

    // Use this for initialization
    void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = (player.transform.position - transform.position);
        float speedModifier = distance.sqrMagnitude > 100 ? 1.1f : 1f;
        float step = Time.deltaTime * speed * speedModifier;
        float oldY = transform.position.y;
        Vector3 movement = distance.normalized * step;
        transform.Translate(movement);
        //  transform.position= Vector3.MoveTowards(transform.position, player.transform.position, step);
        // transform.position = new Vector3(transform.position.x, oldY, transform.position.z);
        //this.GetComponent<CharacterController>().Move(new Vector3(0.01f, 0, 0.01f));
    }

    public void Damage(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
