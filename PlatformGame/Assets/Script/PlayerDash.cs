using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    public float horizontalMove = 0f;
    public Transform playerScale;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * dashSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (direction == 0)
        {
            if(Input.GetMouseButtonDown(1))
            {
                if (playerScale.localScale.x == 1)
                {
                    Debug.Log("Dash right!");
                    direction = 1;
                }
                else if (playerScale.localScale.x == -1)
                {
                    Debug.Log("Dash left");
                    direction = 2;

                }
            }

        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.fixedDeltaTime;

                if (direction == 1)
                {
                    rb.AddForce(new Vector2(10 * dashSpeed, 0));
                    //rb.velocity = Vector2.right * dashSpeed;
                }
                else if (direction == 2)
                {
                    rb.AddForce(new Vector2(0, 10 * dashSpeed));
                    //rb.velocity = Vector2.left * dashSpeed;
                }
            }
        }
    }
}
