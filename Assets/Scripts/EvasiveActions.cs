using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveActions : MonoBehaviour {

    public float dodge;
    public float smoothAction;
    public float tilt;
    public Vector2 waitInterval;
    public Vector2 duration;

    private Vector2 viewportWidth;
    private float targetSpeed;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        UpdateBoundarys();
        StartCoroutine(Evade());
    }

    private void UpdateBoundarys()
    {
        Vector2 halfDimensions = Utils.GetDimensionsInWorldUnits() / 2;


        this.viewportWidth.x = -halfDimensions.x + 0.7f;
        this.viewportWidth.y = halfDimensions.x - 0.7f;
    }

    IEnumerator Evade()
    {
        do
        {
            yield return new WaitForSeconds(Random.Range(waitInterval.x, waitInterval.y));

            targetSpeed = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);

            yield return new WaitForSeconds(Random.Range(duration.x, duration.y));

            targetSpeed = 0;
        } while (true);
    }

    void FixedUpdate () {
        float newSpeed = Mathf.MoveTowards(rb.velocity.x, targetSpeed, Time.deltaTime * smoothAction);
        rb.velocity = new Vector3(newSpeed, 0f, rb.velocity.z);
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, viewportWidth.x, viewportWidth.y), 0, rb.position.z);

        rb.rotation = Quaternion.Euler(0f, 0f, -tilt * newSpeed);
    }
}
