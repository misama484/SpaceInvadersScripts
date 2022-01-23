using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaScript : MonoBehaviour
{
    GameObject spaceShip;   //instanciamos un GO para la nave
    SpaceShipScript scriptNave;
    
    void Start()
    {
        //buscamos la nave por tag y se la asignamos a la variable
        spaceShip = GameObject.FindGameObjectWithTag("SpaceShip");
        //accedemos a la funcion que desbloquea el disparo
        scriptNave = spaceShip.GetComponent<SpaceShipScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)  //cuando la bala choque contra el boxcollider de final de la pantalla, se eliminara
    {
        scriptNave.SetDisparo(); //resetea el contador a 0 y permite volver a disparar
        Destroy(gameObject); //elimina la bala al salir de la pantala
        
    }
    
} 
