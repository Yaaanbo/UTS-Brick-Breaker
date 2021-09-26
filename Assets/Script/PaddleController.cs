using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    Rigidbody2D rb;
    float moveHorizontal;
    public float runSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
       
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveHorizontal * runSpeed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.Equals("batas samping"))
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

}
