using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private GameObject player;
    private float health = 100;

    // Use this for initialization
    void Start () {
	    if(player== null)
        {
            player = GameObject.Find("Player");
        }
	}
	
	// Update is called once per frame
	void Update () {
        float step = Time.deltaTime * 10;
        float oldY = transform.position.y;
        Vector3 movement = (player.transform.position- transform.position).normalized * step;
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
