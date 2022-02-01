 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipScript : MonoBehaviour
{

    public int force;   //fuerza de la nave
    public int forceTorpedo;
    Rigidbody2D myRB;
    public GameObject torpedo;
    public int contador = 0;
    GameObject gameOver;
    GameObject Enemy;
    
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        gameOver = GameObject.FindGameObjectWithTag("GameOver");
        gameOver.SetActive(false);
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    
    void FixedUpdate()
    {
        //GESTIONAMOS MOVIMIENTO DE LA NAVE =>
            //Horizontal
        float movementH = Input.GetAxis("Horizontal");
            //Vertical
        float movementV = Input.GetAxis("Vertical");
        //creamos un vector2 con las capturas de teclado
        Vector2 movement = new Vector2(movementH, movementV);

        //myRB.AddForce(transform.right * movement * force); //=> movimiento mas fluido, menos rapido
        //myRB.velocity = transform.right * movementH * force;  //=> mas rapido pero mas brusco
            //Horizontal y Vertical
        myRB.velocity = movement * force;


            //Limites de la pantalla
        float xPos = Mathf.Clamp(myRB.transform.position.x, -7.5f, 7.5f);
        float yPos = Mathf.Clamp(myRB.transform.position.y, -9f, 9f);
       // transform.position = new Vector2 (xPos, myRB.transform.position.y);
        transform.position = new Vector2(xPos, yPos);

        //GESTIONAMOS DISPARO
        
        if (Input.GetButton("Jump") && contador < 1)
        {
            //al presional "jump, creamos la posicion inicial del torpedo, la misma que la nave + 1.5
            Vector2 posTorpedo = new Vector2(transform.position.x, transform.position.y + 1.5f);

            //instanciamos un nuevo objeto torpedo por cada frame de pulsacion de "jump"(espacio)
            GameObject misil = Instantiate(torpedo, posTorpedo, Quaternion.identity);

            //accedemos al RB del misil, para aplicar fisicas
            Rigidbody2D misilRB = misil.GetComponent<Rigidbody2D>();

            //creamos un vector2 que definira la direccion
            Vector2 direccion = new Vector2(0f, 1f);
            //bien con addforce o velocity, definimos el movimiento del misil, multiplicando por una fuerza para dar velocidad

            //cloneRB.AddForce(direccion * forceTorpedo);
            misilRB.velocity = direccion * forceTorpedo;

            contador = 1; //al poner el contador a uno, ya no entra en el if

        }    
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        contador = 0;
       if(collision.gameObject.tag == "Enemy")
        {
            gameOver.SetActive(true);
            //Destroy(gameObject);
            gameObject.SetActive(false);
            //acceder al enemigo y hacer que no se mueva, parando la corrutina??
            Enemy.SetActive(false);
     
            
        }
    }

    public void SetDisparo() //al ser llamada por el torpedo al pasar la zona de disparo, permitira disparar de nuevo
    {
        contador = 0;
    }                         

    




}
