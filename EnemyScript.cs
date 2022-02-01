using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{


    GameObject player;
    GameObject youWin;
    GameObject spaceShip;
    SpaceShipScript spaceShipScript;

  
    void Start()
    {

        youWin = GameObject.FindGameObjectWithTag("YouWin");
        youWin.SetActive(false);

        spaceShip = GameObject.FindGameObjectWithTag("SpaceShip");
        spaceShipScript = spaceShip.GetComponent<SpaceShipScript>();
        
    }

    
    void Update()
    {
        
    }

   
    //metodo que controla que cuando SOLO un misil toque el enemigo, se destruya.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Rocket")    //de este modo solo interactua con el GO con el tag "Rocket"
        {
            //destruimos enemigo
            Destroy(gameObject);
            //activamos el cartel
            youWin.SetActive(true);
            //al poner el contador a 1, evitamos que pueda volver a disparar 
            spaceShipScript.contador = 1;
        }
        
        
    }
}
