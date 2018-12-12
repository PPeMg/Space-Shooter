using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovementController : MonoBehaviour {

    public float speed;

    private Rigidbody rig;
	
    void Awake () {
        rig = GetComponent<Rigidbody>();
	}

    void Start()
    {
        rig.velocity = transform.forward * speed;
    }
}
