using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    public float lifetime;
    private float age;
	
	// Update is called once per frame
	void Update () {
        age += Time.deltaTime;
        if (age > lifetime)
        {
            Destroy(this.gameObject);
        }
	}
}
