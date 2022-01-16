 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipScript : MonoBehaviour
{

    public int force;   //fuerza de la nave
    public int forceTorpedo;
    Rigidbody2D myRB;
    public GameObject torpedo;
    
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>(); 
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
        if (Input.GetButton("Jump"))
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
        }

        //CODIGO MUESTRA
        /*
        //input.getAxis captura las pulsaciones de las teclas de direccion, horizontal y vertical,
        //modificables desde Edit/projectSettings/inputManager
        float movement = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        if (movement != 0)
        {
            transform.Translate(movement, 0, 0);
        }
        */
    }
}
