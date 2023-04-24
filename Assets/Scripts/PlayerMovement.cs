using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public GameObject ScratchPrefab;
    public BarraDeVida barraDeVida; 
    
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    private float LastScratch;
    public int Health;
    public int Damage;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("running", Horizontal != 0.0f);

        //Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }
        else Grounded = false;

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && Grounded)
        {
            Jump();
        }

        //Scratch
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Entra de scratch?");
            Scratch();
            //Debug.Log("Sale de scratch?");
            LastScratch = Time.time;
            //Destroy(gameObject);
        }

    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void Scratch()
    {
        Vector3 direction;
        if (transform.localScale.x == -1.0f) direction = Vector3.left;
        else direction = Vector3.right;

        //Debug.Log("Direction: " + direction);
        //Debug.Log("Transform.position: " + transform.position);
        GameObject scratch = Instantiate(ScratchPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        scratch.GetComponent<ScratchScript>().SetDirection(direction);
    }

    public void Hit()
    {
        Health -= Damage;

        barraDeVida = FindObjectOfType<BarraDeVida>();

        barraDeVida.vidaActual -= (100/Damage);
        barraDeVida.Update();

        if (Health == 0) Destroy(gameObject);
    }


}

