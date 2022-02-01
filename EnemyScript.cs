using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //booleana que indicara cuando ha llegado al limite de la pantalla, para volver.
    bool mueveDerecha = true;
    //inidica el tiempo que pasa para iniciar el movimiento lateral de nuevo(corrutina)
    float sleep = 0.5f;

    GameObject player;
    GameObject youWin;
    GameObject spaceShip;
    SpaceShipScript spaceShipScript;

  
    void Start()
    {
        //ejecuta la funcion moveEnemy a los 0.5 segundos, y lo repite cada 0.5 segs.
        //InvokeRepeating("moveEnemy", 0.5f, 0.5f);

        //Con corrutinas:        
            StartCoroutine(Wait());

        youWin = GameObject.FindGameObjectWithTag("YouWin");
        youWin.SetActive(false);

        spaceShip = GameObject.FindGameObjectWithTag("SpaceShip");
        spaceShipScript = spaceShip.GetComponent<SpaceShipScript>();
        
    }

    
    void Update()
    {
        
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(sleep);
        MoveEnemy();
        StartCoroutine(Wait());
    }

   void MoveEnemy()
    {
        if (mueveDerecha)
        {            
            if(transform.position.x > 6.5)
            {
                sleep -= 0.05f;    //restamos tiempo a la corrutina cuando llegue al limite de pantalla, para aumentar velocidad
                mueveDerecha = false;
                transform.Translate(Vector3.down);  //bajamos una linea los enemigos
            }
            else
            {
                transform.Translate(Vector3.right); //movemos a la derecha
            }
        }
        else
        {
            
            if(transform.position.x < -6.5)
            {
                sleep -= 0.05f;
                mueveDerecha =true;
                transform.Translate(Vector3.down);
            }
            else
            {
                transform.Translate(Vector3.left);
            }
        }
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
