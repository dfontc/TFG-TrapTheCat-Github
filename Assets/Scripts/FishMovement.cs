using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;

    float xInicial, yInicial;
    float cronometro = 0;
    public GameObject Player;
    public GameObject tree;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        //Animator = GetComponent<Animator>();
        xInicial = transform.position.x;
        yInicial = transform.position.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Change){
            cronometro += 1f * Time.deltaTime;
            //if (cronometro >= 50){
            if (!tree.activeSelf){
                xInicial += 0.001f;
                transform.position = new Vector2(xInicial, yInicial);
            }
        //}
    }

}
