using System;
using System.Collections;
using UnityEngine;

public class MovementMain: MonoBehaviour
{
    Functions f= new Functions();
    //aquí está el movimeinto básico del pesonaje
    float monedas=0;

    public int lifePlayer = 5;//variable privada para evitar hackeo 
    public GameObject wheelSkill;   
    public GameObject cameraMain;
    public float velocityMovement;//variable privada o protected
    //public float velocityCameraY;
    public float velocityCameraX;
    public int forceJump = 300;
   public int forceDash = 300;//variable usada en otro lugar
    public bool couldJump = true;
    public bool twoJump = false;
    public bool focusCamera = false;
    //float timeActual = 0;
    //int timeSeconds;
    //public int numberEnemy = 4;
    public float numberEnemy=4;//variable usada en otro lugar
    Rigidbody Rigidbody;
    Animator animator;

   //habilidades
   // public int opcionBotas = 0;
   
    void Start()
    {
        animator = GetComponent<Animator>();//obtencion del arbol de animaciones
        Rigidbody = GetComponent<Rigidbody>();
      
    }
    void Update()
    {
            //movimiento hacia adelante     
                transform.Translate(0, 0, f.moverY(animator, velocityMovement));
    
            //rotacion de personaje
            transform.Rotate(0, Input.GetAxisRaw("Horizontal") * 3f, 0);
            //habilidad de saltar

            //this conditional is used to determinate de jump type
            if (Input.GetKeyDown(KeyCode.Space))
            {
                f.Jump(forceJump, couldJump, twoJump, Rigidbody);
            }
            //modos de movimiento de la camara
            //With this functión we can pin up the camera un a place
           
                f.focusCamera(focusCamera, cameraMain, velocityCameraX, transform);
            //aqui se oculta o no la rueda de actividades
            //With this code we can hide or show the activities wheel
            f.actvitiesWheel(cameraMain, wheelSkill);
        if (Input.GetKey(KeyCode.E))
        {
            //llamado a la funcion de correr
            f.run(animator, velocityMovement, transform);
            //CONTADOR DE TIEMPO JUGANDO...
        }
        
           else
            {
                animator.SetBool("correr", false);//esto se corregirá luego
            }
       
            /*  timeActual += Time.deltaTime;
              timeSeconds = (int)timeActual;*/
            //Hacer una funcion counter time    
    }
    //funcion para mover personaje hacia adelante y atrás          
// se verifica si está tocando el piso
private void OnCollisionStay(Collision collision)
    {
        couldJump = f.ableJump(animator);

    }
    private void OnCollisionExit(Collision other)
    {
        couldJump = f.enableJump(animator);
    }


 private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="item"  )
        {
            Debug.Log("SIRVE");
            Destroy(other.gameObject);
      monedas++;

            GetComponent<AudioSource>().Play();
        }

            if (other.tag == "item2")
            {

                Destroy(other.gameObject);
              

            }

    }

    //Clase cortinas
    IEnumerator WaitTime(float tiempo, Action accion)
    {
        yield return new WaitForSecondsRealtime(tiempo);
        accion();
    }
}
