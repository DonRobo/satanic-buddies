using UnityEngine;
using System.Collections;

public class Decoy : MonoBehaviour {

    public float lifetime = 5;
    private float age = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        age += Time.deltaTime;
        if (age > lifetime)
        {
            Destroy(this.gameObject);
        }
	}
}
