using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public float speed = 10;
    private GameObject player;
    private float health = 100;
    public float damage = 5;
    public float attackCooldown = 1;
    private float attackAge = 0;

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
        attackAge += Time.deltaTime;
        Vector3 distance = (player.transform.position - transform.position);

        Decoy[] decoys = GameObject.FindObjectsOfType<Decoy>();
        if (decoys.Length > 0)
        {
            Vector3 closestDecoyDistance = decoys[0].gameObject.transform.position - transform.position;
            foreach (Decoy decoy in decoys)
            {
                if ((decoy.gameObject.transform.position - transform.position).sqrMagnitude < closestDecoyDistance.sqrMagnitude)
                {
                    closestDecoyDistance = decoy.gameObject.transform.position - transform.position;
                }
            }

            distance = closestDecoyDistance;
        }

        if (distance.sqrMagnitude > 8)
        {
            float speedModifier = distance.sqrMagnitude > 100 ? 1.1f : 1f;
            float step = Time.deltaTime * speed * speedModifier;
            Vector3 movement = distance.normalized * step;
            transform.Translate(movement);
        }
        else
        {
            if (decoys.Length == 0)
            {
                if (attackAge > attackCooldown)
                {
                    player.GetComponent<PlayerController>().Damage(damage);
                    attackAge = 0;
                }
            }
        }
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
