using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Character : MonoBehaviour {
    private float speed = 4.0F;
    private float jumpForce = 10.0F;

    public static int score = 0, score1 = 0, score2 = 0, score3 = 0;
    public static float key = 0;

    private bool isGrounded = false;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;
    Vector3 direction;
    [SerializeField] Joystick joystickWalk;
    private Text Text;

    GameObject Player1;
    private void Awake () {
        rb = GetComponent<Rigidbody2D> ();
        animator = GetComponent<Animator> ();
        sprite = GetComponentInChildren<SpriteRenderer> ();
        joystickWalk = FindObjectOfType<Joystick> ();
        Text = GameObject.FindObjectOfType<Text> ();
    }

    public void FixedUpdate () {
        CheckGround ();

        if (Mathf.Abs (direction.x) > 0.1)
            transform.position = Vector3.MoveTowards (transform.position, transform.position + direction, speed * Time.fixedDeltaTime);
    }

    private void Update () {
        direction.x = joystickWalk.Horizontal;

        if (Mathf.Abs (direction.x) > 0.1)
            RunWithJoystick ();

        if (Mathf.Abs (direction.x) < 0.1 && isGrounded)
            animator.SetInteger ("State", 0);

        if (Input.GetButton ("Horizontal"))
            RunWithKeyboard ();

        if (Input.GetButtonUp ("Horizontal")) {
            direction = Vector3.zero;
        }

        if (Input.GetKeyDown (KeyCode.UpArrow))
            Jump ();

        score = score1 + score2 + score3;
        Text.text = score.ToString ();

    }

    public void RunWithJoystick () {
        sprite.flipX = direction.x < 0.0F;

        if (isGrounded)
            animator.SetInteger ("State", 1);
    }

    public void RunWithKeyboard () {
        direction = transform.right * Input.GetAxis ("Horizontal");
        sprite.flipX = direction.x < 0.0F;
        if (isGrounded)
            animator.SetInteger ("State", 1);
    }
    public void Jump () {
        if (isGrounded) {
            rb.AddForce (transform.up * jumpForce, ForceMode2D.Impulse);
            animator.SetInteger ("State", 2);
        }
    }
    private void CheckGround () {
        Collider2D[] colliders = Physics2D.OverlapCircleAll (transform.position, 0.2F);

        isGrounded = colliders.Length > 1;

        if (!isGrounded)
            animator.SetInteger ("State", 2);
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.CompareTag ("enemy")) {
            SceneManager.LoadScene (3);
            key = 0;
            score3 = 0;
        }
    }

    void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.CompareTag ("coin")) {
            Destroy (col.gameObject);
            score1++;
        }

        if (col.gameObject.CompareTag ("coin2")) {
            Destroy (col.gameObject);
            score2++;
        }

        if (col.gameObject.CompareTag ("coin3")) {
            Destroy (col.gameObject);
            score3++;
        }

        if (col.gameObject.CompareTag ("key")) {
            Destroy (col.gameObject);
            key++;
        }

        if (col.gameObject.CompareTag ("death")) {
            SceneManager.LoadScene (1);
            score1 = 0;
            key = 0;
        }

        if (col.gameObject.CompareTag ("death1")) {
            SceneManager.LoadScene (2);
            key = 0;
            score2 = 0;

        }

        if (col.gameObject.CompareTag ("death2")) {
            SceneManager.LoadScene (3);
            key = 0;
            score3 = 0;
        }
    }
}