using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerJump : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    bool isGrounded;
    public float jumpForce;

    public Text CoinVisual;
    public int coinCount;
    public Text ScoreVisual;
    public int ScoreSystem;
    public PlayerController GroundController;
    private void Start()
    {
        coinCount = 0;
        
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ScoreVisual.text = (ScoreSystem + GroundController.speed).ToString();
        ScoreSystem++;
        CoinVisual.text = coinCount.ToString();
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    public void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            coinCount+= 5;
            Destroy(collision.gameObject);
        }
    }
}
