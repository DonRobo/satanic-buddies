﻿using UnityEngine;
using System.Collections;

public class Comet : MonoBehaviour {
	
	public GameObject explosionPrefab;
	public float damage = 90;
	public float force = 1000;
	public float range = 8;

	// Use this for initialization
	void Start () {
	}

	 //Update is called once per frame
		void Update () {
		float step = Time.deltaTime * 20;
		Vector3 movement = (Vector3.down) * step;
		transform.Translate(movement);

		if(Mathf.Abs(transform.position.y) < 0.2)
        {
			GameObject explosion = GameObject.Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
			explosion.GetComponent<Explosion>().force = force;
			explosion.GetComponent<Explosion>().range = range;
			explosion.GetComponent<Explosion>().damage = damage;
			Destroy(this.gameObject);
		}
	}
}
