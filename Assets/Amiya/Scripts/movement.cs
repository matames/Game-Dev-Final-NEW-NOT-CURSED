using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed;

    public Animator animator;

    SpriteRenderer myRenderer;

    public Rigidbody2D myBody;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = gameObject.GetComponent<SpriteRenderer>();

        myBody = gameObject.GetComponent<Rigidbody2D>();
        myBody.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.D))
        {
            pos.x += speed * Time.deltaTime;

            myRenderer.flipX = false;

            animator.SetBool("side", true);
            animator.SetBool("back", false);
            animator.SetBool("walking", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            pos.x -= speed * Time.deltaTime;

            myRenderer.flipX = true;

            animator.SetBool("side", true);
            animator.SetBool("back", false);
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            pos.y += speed * Time.deltaTime;

            animator.SetBool("back", true);
            animator.SetBool("side", false);
            animator.SetBool("walking", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            pos.y -= speed * Time.deltaTime;

            animator.SetBool("back", false);
            animator.SetBool("side", false);
            animator.SetBool("walking", true);
        }
        else if(!animator.GetBool("walking"))       // if player is not walking to the side
        {
            animator.SetBool("walking", false);
        }

        transform.position = pos;
    }

}
