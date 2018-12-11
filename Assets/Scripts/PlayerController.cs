using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    public float speed;
    public float tilt;
    public Boundary boundary;

    private Rigidbody rig;

    void Awake () {
        rig = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
        float speedHorizontal = Input.GetAxis("Horizontal") * speed;
        float speedVertical = Input.GetAxis("Vertical") * speed;
        float speedRotation = Input.GetAxis("Horizontal");

        rig.velocity = new Vector3(speedHorizontal, 0f, speedVertical);
        rig.position = new Vector3(Mathf.Clamp(rig.position.x, boundary.xMin, boundary.xMax), 0, Mathf.Clamp(rig.position.z, boundary.zMin, boundary.zMax));

        rig.rotation = Quaternion.Euler(0f, 0f, -1 * tilt * speedRotation);
	}
}
