using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public Projectile projectile;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject.Instantiate(projectile, transform.position + projectile.direction.normalized, Quaternion.identity);
        }
	}
}
