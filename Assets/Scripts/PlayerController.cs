using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float walkSpeed = .3f;

    // Maximum Z deviation that the player can have
    public float worldZLimit = 1.0f;

    private Vector3 initialPosition;

	
	void Start ()
    {
        initialPosition = transform.position;
	}
	
	void Update ()
    {
        float translationZ = Input.GetAxis("Vertical") *  walkSpeed;
        float translationX = Input.GetAxis("Horizontal") * walkSpeed;

        float newZ = transform.position.z + translationZ;

        newZ = Mathf.Clamp(newZ, initialPosition.z - worldZLimit, initialPosition.z + worldZLimit);
        
        transform.Translate(translationX, 0, newZ - transform.position.z);
    }
}
