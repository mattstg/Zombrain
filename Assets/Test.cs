using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    /*
     * 
     * Guy Demers

    Bug/Balance Fixes
    //Fix the following issues in the game
    1) The walls are invisible, make them visible again ✓
    2) Everything is shoved outside the screen when the game starts, fix that issue. ✓
    3) Bullets do not seem to affect zombies ✓
    4) The code that stops zombies and humans from spawning in walls seems to be bugged ✓
    5) Set number of humans to spawn to 100 ✓
   

    Research
    //Awnser the following questions with enough detail to explain to someone who hasn't seen the game or code yet
    1) How and where is the animations for the different unit types controlled, both in code and editor? 
        For example, there is no animation code in Player, yet it has different animations than Zombie

    For the player character, the animation controller can be find inside the Animations repo at the source. You will find the playerAnimatorController
    which contains a blend tree of 4 differents animations triggered by the result of the getDir() function inside the code. Each animation
    gets triggered by Input.GetAxis("Horizontal") && Input.GetAxis("Vertical"). ** You can find the code for the GetDir() function declared
    inside the Unit class which is the base class for all movement accros each Unit class ex: Zombie, Human && Player. Each class then 
    override the function to adjust its movement accordingly.

    Since they are both inheriting the class Unit or a child of the class Unit, they both have access to the function UpdateUnit which also make a 
    call for the function UpdateAnimator which takes a direction in parameter of its function and it is the reason why the class Zombie
    and Player behave differently.


    2) Explain the flow of the movement system of the Humans? At what point does the movement calculation differ from Zombies?

    They only differ because of the class Human which is overriding the GetDir function by multiply by a scalar value so that the direction
    gets inverted to simulate a respond in bahaviour where a human sees a zombie and run away.

    3) Who has a further detection range Humans or Zombies?

    Zombies

    4) How do zombies pick their targets to follow?

    With the function FindClosestTarget(out Vector2 targetPos). Inside, their is a call for another function called : GetClosestHumanToPoint()
    which is doing math to calculate the closest distance from a certain point and return the human that is at the position of this transform.


    5) Explain the use of the out keyword and bool return type in FindClosestTarget. Why do you assume that design was used?

    Variables passed as an Out arguments doesnt have to be initialized to be used. It is pass as a reference which can be updated easily
    from inside that same function.
    
    New Features
    -Make A HUD that shows the amount of ammo by showing pictures of ammo in a Horizontal layout group
    -Make the HUD showcase the number of humans and zombies as text













     */
}
