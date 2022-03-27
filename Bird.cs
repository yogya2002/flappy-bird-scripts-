using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private bool isDead = false;
    //intially the player isnt dead so we have made a boolvariable to alter the state of the game 

    private Rigidbody2D rb2d;
    // to apply the physics we need to make a variable to give reference to the player 

    public float upForce = 200f;
    //this variable will store how much will the force by which the player will be dislpaced in y direction
    private Animator anim;
    // this variable will be used as a refernce to the animator component and will be used for playing animations 


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        // when the game starts this will give the reference to the rigidbody component attached to the player 

        anim = GetComponent<Animator>();
        // when the game start it will activate the animator and animations 

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)//if the player isnt dead 
        {
            if (Input.GetMouseButton(0))
            //if the player isnt dead and presses the mosuse button then 
            {
                rb2d.velocity = Vector2.zero;
                // if the player aint dead and have clicked the mouse button then we add velocity in y direction and reset it everytime to zero 
                // this is an inconsistant way to do this thing but if we want some accurate simulation then we wiil need something more percise than this 
                // this is really suiable for cartoony style games 
                // the other thing we are going to do is we will add force to the palyer means how much in y direction should the player move 

                rb2d.AddForce(new Vector2(0, upForce));
                //we will add the force that will be equal to upforce in y direction and as the game will move vertically there is no need to add force in x direction 
                // we will use vector 2 as a reference 

                anim.SetTrigger("Flap");
                // trigger the flap and then the animator will play the flap animation 

            }
        }
    }

    void OnCollisionEnter2D()
        //this is a inbuilt function in unity when unity detects a collision 
    {
        // this automatically creates a logic if the bird have collided on an element that already have a rigid body component on it then set the isDead variable to be true 
        isDead = true;
        anim.SetTrigger("Die");

        GameController.instance.BirdDied();
    }
}