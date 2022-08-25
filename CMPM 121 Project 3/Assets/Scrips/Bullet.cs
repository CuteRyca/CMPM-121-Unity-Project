using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rigidbody;
    public float speed;
    public float damage = 10f;
    GameObject player;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        direction = player.transform.forward;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody.AddForce(direction * speed * Time.deltaTime, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

    }
}
