using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float jumpForce;

    public Score score;
    public WallSpawner spawner;

    private bool callOnce;
    private Quaternion downRotation;
    private Quaternion forwardRotation;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;

        forwardRotation = Quaternion.Euler(0, 0, 45);
        downRotation = Quaternion.Euler(0, 0,-85);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            transform.rotation = forwardRotation;
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(Vector2.up * jumpForce);
            
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
            transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, 2 * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            score.SetHighscore();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
