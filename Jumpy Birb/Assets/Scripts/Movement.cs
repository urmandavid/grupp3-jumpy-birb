using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float jumpForce;

    private Animator anim;
    private SfxManager sfx;

    public Score score;
    public WallSpawner spawner;

    private bool callOnce;
    private Quaternion downRotation;
    private Quaternion forwardRotation;

    // Start is called before the first frame update
    void Start()
    {
        sfx = FindObjectOfType<SfxManager>();
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;

        forwardRotation = Quaternion.Euler(0, 0, 25);
        downRotation = Quaternion.Euler(0, 0,-75);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            transform.rotation = forwardRotation;
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(Vector2.up * jumpForce);
            anim.SetTrigger("Swim");
            sfx.playSwimSound();
            
            if(!callOnce)
            {
                callOnce = true;
                score.startedJumping = true;
                score.SetSpaceToPlayTextInactive();
                rb2d.gravityScale = 3;
                spawner.startSpawning();
            }
        }

        if(callOnce)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, 0.7f * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            sfx.playDeathSound();
            score.SetHighscore();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
    }
}
