using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {

    Animator animator;

    float walkSpeed = 10;

	// Use this for initialization
	void Start () {
        animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("right")) {
           transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
        }
    }
}
