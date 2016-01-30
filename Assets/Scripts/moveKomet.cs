using UnityEngine;
using System.Collections;

public class moveKomet : MonoBehaviour {

	public GameObject player;
	private Vector3 target;

	// Use this for initialization
	void Start () {
		if(player== null)
		{
			player = GameObject.Find("Player");
		}
		target = player.transform.position;
	}

	// Update is called once per frame
	void Update () {
		float step = Time.deltaTime * 10;
		Vector3 movement = (target - transform.position).normalized * step;
		transform.Translate(movement);
		//  transform.position= Vector3.MoveTowards(transform.position, player.transform.position, step);
		// transform.position = new Vector3(transform.position.x, oldY, transform.position.z);
		//this.GetComponent<CharacterController>().Move(new Vector3(0.01f, 0, 0.01f));
	}
}
