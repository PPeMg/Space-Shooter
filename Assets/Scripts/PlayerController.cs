using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    [Header("Movement")]
    public float speed;
    public float tilt;
    public Boundary boundary;

    private Rigidbody rig;

    [Header("Shoot")]
    public GameObject shoot;
    public float fireRate;

    private float nextFire;
    private Transform shootSpawn;

    void Awake () {
        rig = GetComponent<Rigidbody>();

        shootSpawn = GameObject.Find("Shoot Spawn").GetComponent<Transform>();
        nextFire = 0f;
	}

    private void Start()
    {
        UpdateBoundarys();
    }

    private void UpdateBoundarys()
    {
        Vector2 halfDimensions = Utils.GetDimensionsInWorldUnits() / 2;
        

        this.boundary.xMin = -halfDimensions.x + 0.7f;
        this.boundary.xMax =  halfDimensions.x - 0.7f;
        this.boundary.zMin = -halfDimensions.y + 6f;
        this.boundary.zMax =  halfDimensions.y - 2f;
    }

    private void Update()
    {
        if (CrossPlatformInputManager.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shoot, shootSpawn.position, Quaternion.identity);
        }
    }

    void FixedUpdate () {
        float speedHorizontal = CrossPlatformInputManager.GetAxis("Horizontal") * speed;
        float speedVertical = CrossPlatformInputManager.GetAxis("Vertical") * speed;
        float speedRotation = CrossPlatformInputManager.GetAxis("Horizontal");

        rig.velocity = new Vector3(speedHorizontal, 0f, speedVertical);
        rig.position = new Vector3(Mathf.Clamp(rig.position.x, boundary.xMin, boundary.xMax), 0, Mathf.Clamp(rig.position.z, boundary.zMin, boundary.zMax));

        rig.rotation = Quaternion.Euler(0f, 0f, -1 * tilt * speedRotation);
	}
}
