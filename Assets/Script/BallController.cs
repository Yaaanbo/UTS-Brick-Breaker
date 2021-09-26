using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    private int score;
    public Text scoreText;
    public GameObject winningUI;
    public GameObject losingUI;
    public Rigidbody2D rb;
    public float speed = 500f;
    public float maxBounceAngle = 75f;
    public int nyawa = 3;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        nyawa = 3;
        score = 0;
        scoreIncrement();
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;
        rb.AddForce(force.normalized * speed);
    }
    private void Update()
    {
        if (score == 16)
        {
            youWin();
            Time.timeScale = 0;
        }
        youLose();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       BallController Ball = collision.gameObject.GetComponent<BallController>();

       if (Ball != null)
       {
            Vector3 position = transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            float offset = position.x - contactPoint.x;
            float lebar = collision.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, rb.velocity);
            float bounceAngle = (offset / lebar) * maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -maxBounceAngle, maxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            Ball.rb.velocity = rotation * Vector2.up * Ball.rb.velocity.magnitude;
       }

        if (collision.gameObject.tag == "brick")
        {
            score++;
            scoreIncrement();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "batas bawah")
        {
            ballReset();
            nyawa--;
        }
    }
    void scoreIncrement()
    {
        scoreText.text = score.ToString();
    }
    void youWin()
    {
        winningUI.SetActive(true);
        
    }
    void ballReset()
    {
        transform.localPosition = new Vector2(0, -1.83f);
    }
    void youLose()
    {
        if(nyawa == 0)
        {
         losingUI.SetActive(true);
         Time.timeScale = 0;
        }
        else if(nyawa != 0)
        {
            Time.timeScale = 1;
        }
    }
}
