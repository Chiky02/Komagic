using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions 
{
    Animator_Define anim=new Animator_Define();
   //Forward an back movement
   public float moverY(Animator animator, float velocityMovement)
    {
        float f = Input.GetAxis("Vertical");//deteccion de la palanca vertical

      
        if (f > 0)//para mover hacia adelante flecha arriba
        {

            anim.moveY(animator);
            return f * velocityMovement;
        }
        else if (f < 0)//para mover hacia atr�s flecha abajo
        {
            anim.moveY(animator);
            return (f * velocityMovement);
        }


        else
        {
           
            animator.SetBool("caminar", false);
            return 0;


        }

    }


    public void Jump(int forceJump,bool couldJump, bool twoJump, Rigidbody Rigid)
    {

     
              
            if (couldJump)
            {
                if (twoJump)
                {
                    //aqui hay doble salto
                    Rigid.AddForce(0, forceJump * 2, 0);
                  

                }
                else
                {
                    //aqui solo hay uno
                    Rigid.AddForce(0, forceJump, 0);
                }
            }
        
    }

    public void focusCamera(bool focusCamera, GameObject cameraMain, float velocityCameraX, Transform transform)
    {

        if (focusCamera == true)
        {
            //camara para apuntar

            cameraMain.transform.parent.parent.Rotate(0, Input.GetAxis("Mouse X") * velocityCameraX, 0);

        }
        else
        {
            //camara normal
            cameraMain.transform.parent.Rotate(0, Input.GetAxis("Mouse X") * velocityCameraX, 0);

            if (Input.GetKey(KeyCode.N))
            {
                Debug.Log("Funciona   " + cameraMain.transform.parent.rotation.eulerAngles.y);
                float xd = cameraMain.transform.parent.rotation.eulerAngles.y;


               transform.Rotate(0, cameraMain.transform.parent.rotation.eulerAngles.y, 0);
                cameraMain.transform.parent.parent.Rotate(0, 0, 0);


            }
        }


    }

   public void actvitiesWheel(GameObject cameraMain, GameObject wheelSkill)



    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {

            //se activa la rueda de habilidades
            wheelSkill.SetActive(true);
            cameraMain.transform.parent.localPosition += new Vector3(0, 0, 0.9f);

        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            //se desactiva la rueda de habilidades
            wheelSkill.SetActive(false);
            cameraMain.transform.parent.localPosition -= new Vector3(0, 0, 0.9f);
        }

    }

    public void run(Animator animator, float velocityMovement,Transform transform) {
   
            anim.run(animator);
            transform.Translate(0, 0, 2 * velocityMovement);

      

     

    }
    public bool ableJump( Animator animator) {

        anim.jumpping(animator);
        return true;
    
    }

    public bool enableJump( Animator animator)
    {

        anim.notJumping(animator);
        return false;

    }

}
