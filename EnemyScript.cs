using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //booleana que indicara cuando ha llegado al limite de la pantalla, para volver.
    bool mueveDerecha = true;
    //inidica el tiempo que pasa para iniciar el movimiento lateral de nuevo(corrutina)
    float sleep = 0.5f;
  
    void Start()
    {
        //ejecuta la funcion moveEnemy a los 0.5 segundos, y lo repite cada 0.5 segs.
        //InvokeRepeating("moveEnemy", 0.5f, 0.5f);

        //Con corrutinas:        
            StartCoroutine(Wait());       
    }

    
    void Update()
    {
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(sleep);
        MoveEnemy();
        StartCoroutine(Wait());
    }

   void MoveEnemy()
    {
        if (mueveDerecha)
        {            
            if(transform.position.x < 6.5)
            {
                sleep -= 0.005f;    //restamos tiempo a la corrutina cuando llegue al limite de pantalla, para aumentar velocidad
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
            
            if(transform.position.x > -6.5)
            {
                sleep -= 0.005f;
                mueveDerecha =true;
                transform.Translate(Vector3.down);
            }
            else
            {
                transform.Translate(Vector3.left);
            }
        }
    }
}
