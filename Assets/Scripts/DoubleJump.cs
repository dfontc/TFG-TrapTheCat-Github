using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator animator;

    public float fuerzaSalto;
    public LayerMask queEsSuelo;
    public Transform controladorSuelo;
    public Vector3 dimensionesCaja;

    private bool enSuelo;
    private bool salto = false;

    public int saltosExtraRestantes;
    public int saltosExtra;
    // Start is called before the first frame update
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);

        if (enSuelo)
        {
            saltosExtraRestantes = saltosExtra;
        }

        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            salto = true;
        }
    }
    private void FixedUpdate(){
        Movimiento(salto);
        salto = false;
    }

    private void Movimiento(bool salto){
        if(salto){
            if(enSuelo){
                Salto();
            }
            else{
                if(salto && saltosExtraRestantes > 0){
                    Salto();
                    saltosExtraRestantes -= 1;
                }
            }
        }
    }
    private void Salto(){
        rb2D.AddForce(new Vector2(0f, fuerzaSalto));
        salto = false;
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }
}
