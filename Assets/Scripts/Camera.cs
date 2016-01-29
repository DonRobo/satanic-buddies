using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    public float offset;
    public GameObject target;

	// Use this for initialization
	void Start () {
        if (target == null) {
            target = GameObject.Find("Player");
        }
        transform.position = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z + offset);
    }

    // Update is called once per frame
    void Update () {
        transform.position = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
	}
}
