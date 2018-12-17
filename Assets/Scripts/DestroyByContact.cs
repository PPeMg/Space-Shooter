using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;

    private GameController gameController;

    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider other)
    {

        if(!other.CompareTag("Boundary") && !other.CompareTag("Enemy"))
        {
            if(explosion != null)
                Instantiate(explosion, this.transform.position, this.transform.rotation);

            if (other.CompareTag("Player"))
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                gameController.GameOver();
            } else if(other.CompareTag("Shoot")){
                gameController.AddScore(scoreValue);
            }
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
