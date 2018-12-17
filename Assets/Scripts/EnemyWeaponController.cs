using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController : MonoBehaviour {

    public GameObject shoot;
    public Transform shootSpawn;
    public float delay;
    public float fireRate;

    private AudioSource audioSource;

	void Awake () {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        InvokeRepeating("Fire", delay, fireRate);
    }

    void Update()
    {

    }

    void Fire()
    {
        Instantiate(shoot, shootSpawn.position, shootSpawn.rotation);
        audioSource.Play();
    }
}
