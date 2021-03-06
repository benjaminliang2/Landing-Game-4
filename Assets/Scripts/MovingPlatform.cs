using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float distance;
    [SerializeField] float speed;
    private Rigidbody2D rb;
    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();
    }

    private void Move()
    {
        rb.MovePosition(new Vector2(Mathf.PingPong(Time.time * speed, distance),transform.position.y));
        

    }
}
