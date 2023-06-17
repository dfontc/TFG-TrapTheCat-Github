using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public GameObject ScratchPrefab;
    public BarraDeVida barraDeVida; 
    public AudioClip Sound;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    private float LastScratch;
    public int Health;
    public int Damage;
    //public bool saltoExtra = false;
    public int jumpChanges;
    private int startJumpChanges;
    float xInicial, yInicial;

    //private bool isPowerUpCow = false;
    public CowScript cowScript;
    public MilkTimer milkTimer;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        xInicial = transform.position.x;
        yInicial = transform.position.y;
        startJumpChanges = jumpChanges;

    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("running", Horizontal != 0.0f);

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
            jumpChanges = startJumpChanges;
        }
        else Grounded = false;
        
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && (Grounded || (jumpChanges  > 0 && cowScript.isPowerUp  && milkTimer.timer > 1)))
        {
            Jump();
            jumpChanges --;

        }

        //Scratch
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Scratch();
            LastScratch = Time.time;

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

        GameObject scratch = Instantiate(ScratchPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        scratch.GetComponent<ScratchScript>().SetDirection(direction);
    }

    public void Hit()
    {
        Health -= Damage;

        barraDeVida = FindObjectOfType<BarraDeVida>();
      

        barraDeVida.vidaActual -= Damage;
        barraDeVida.Update();
        
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
        if (Health <= 0){
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
    }
     

    public void FallPlayer(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}

