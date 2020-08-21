using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 10f;
    public float damage = 0.2f;
    public float difficulty;
    private Rigidbody rb;
    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        difficulty = FindObjectOfType<WaveController>().difficulty;
        moveSpeed = difficulty * 2;
        damage = difficulty * damage;
        player = FindObjectOfType<RigidbodyFirstPersonController>().transform;
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        rb.rotation = Quaternion.Euler(90, angle, 0);
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector3 direction)
    {
        rb.MovePosition(transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Playerstats>().TakeDamage(damage);
        }
    }
}
