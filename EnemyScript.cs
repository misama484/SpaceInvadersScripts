using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
  
    void Start()
    {
        //ejecuta la funcion moveEnemy a los 0.5 segundos, y lo repite cada 0.5 segs.
        //InvokeRepeating("moveEnemy", 0.5f, 0.5f);

        //Con corrutinas:
        if(transform.position.x == 5.0f)
        {
            StartCoroutine(WaitLeft());
        }
        else if(transform.position.x == -0.5f)
        {
            StartCoroutine(WaitRigth());
        }
        
    }

    
    void Update()
    {
        
    }

    IEnumerator WaitRigth()
    {   
        //esperara 0.8s
        yield return new WaitForSeconds(0.8f);
        moveEnemyRigth();              
        //vuelve a empezar
        StartCoroutine(WaitRigth());
    }

    IEnumerator WaitLeft()
    {
        yield return new WaitForSeconds(0.8f);
        moveEnemyLeft();
        StartCoroutine(WaitLeft());
    }

    void moveEnemyRigth()
    {
        //movera el enemigo un punto a la derecha
        transform.Translate(Vector3.right);
    }
    void moveEnemyLeft()
    {
        //movera el enemigo un punto a la izquierda
        transform.Translate(Vector3.left);
    }
}
