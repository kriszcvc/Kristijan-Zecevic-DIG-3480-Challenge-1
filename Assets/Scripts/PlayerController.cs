using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text healthText;
    public Text loseText;
    public GameObject player;

    private Rigidbody2D rb2d;
    private int count;
    private int health;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        health = 3;
        SetCountText ();
        SetHealthText ();
        winText.text = "";
        loseText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            if (count < 20)
            {
                other.gameObject.SetActive(false);
                health = health - 1;
                SetHealthText();
            }
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if (count == 8)
            {
                transform.position = new Vector2(125.0f, 0.0f);
            }

        if (count == 20)
        {
            winText.text = "You win! Game created by Kristijan Zecevic";
        }
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
        if (health == 0)
        {
            Destroy(player);
            loseText.text = "You lose! Press esc to quit";
        }
    }
}
