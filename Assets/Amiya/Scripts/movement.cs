using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed;

    public Animator animator;

    SpriteRenderer myRenderer;

    public Rigidbody2D myBody;

    public AudioSource walkingAudioSource; //audiosource that carries the walking sfx
    public bool isWalking = false;

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

            isWalking = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            pos.x -= speed * Time.deltaTime;

            myRenderer.flipX = true;

            animator.SetBool("side", true);
            animator.SetBool("back", false);
            animator.SetBool("walking", true);

            isWalking = true;
        }
        else
        {
            animator.SetBool("walking", false);

            isWalking = false;
        }

        if (Input.GetKey(KeyCode.W))
        {
            pos.y += speed * Time.deltaTime;

            animator.SetBool("back", true);
            animator.SetBool("side", false);
            animator.SetBool("walking", true);

            isWalking = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            pos.y -= speed * Time.deltaTime;

            animator.SetBool("back", false);
            animator.SetBool("side", false);
            animator.SetBool("walking", true);

            isWalking = true;
        }
        else if(!animator.GetBool("walking"))       // if player is not walking to the side
        {
            animator.SetBool("walking", false);

            isWalking = false;
        }

        transform.position = pos;

        if (isWalking && !walkingAudioSource.isPlaying)
        {
            walkingAudioSource.Play();
        }
        if (!isWalking)
        {
            walkingAudioSource.Stop();
        }
    }
}
