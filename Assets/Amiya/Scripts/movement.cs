using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed;

    public Animator animator;

    SpriteRenderer myRenderer;

    public Rigidbody2D myBody;

    [SerializeField] private dialogueUI DialogueUI;

    public dialogueUI dialogueUI => DialogueUI;

    public IInteractable Interactable { get; set; }

    public AudioSource walkingAudioSource; //audiosource that carries the walking sfx
    public bool isWalking = false;

    public bool nearWater = false;

    public CastingBar castingBarScript;

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
        //Debug.Log("near water = " + nearWater);

        Vector3 pos = transform.position;

        if (castingBarScript.canMove)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Interactable != null)
                {
                    Interactable.Interact(this);
                }
            }

            if (!DialogueUI.dialogueOn)
            {
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
                else if (!animator.GetBool("walking"))       // if player is not walking to the side
                {
                    animator.SetBool("walking", false);

                    isWalking = false;
                }
            }

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "water")
        {
            nearWater = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "water")
        {
            nearWater = false;
        }
    }
}
