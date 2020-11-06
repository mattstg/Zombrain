using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    /*

    Alexandre Brosseau

    Bug/Balance Fixes
    //Fix the following issues in the game
    1) The walls are invisible, make them visible again - FIXED
    2) Everything is shoved outside the screen when the game starts, fix that issue. - FIXED
    3) Bullets do not seem to affect zombies - FIXED
    4) The code that stops zombies and humans from spawning in walls seems to be bugged - FIXED
    5) Set number of humans to spawn to 100 - FIXED
    
    - Player was missing its "PlayerWalkRight" - FIXED
    - Incorrectly named Zombie WalkSouth animation (was named WalkUp) - FIXED

    Research
    //Awnser the following questions with enough detail to explain to someone who hasn't seen the game or code yet
    1) How and where is the animations for the different unit types controlled, both in code and editor? 
        - The animations for are controller in Unit.cs (UpdateAnimator) function where the animation is changed according to the direction that the entity is moving
        - The code for both Zombies/Humans and Player is the same, the function will take the entity direction as a parameter and set the proper floats for the Animator
        - The only real difference that I found in the AnimationControllers are the name of the Animations, the name of the animations for the Player have a "Player" prefix

    2) Explain the flow of the movement system of the Humans? At what point does the movement calculation differ from Zombies?
        - The human will iterate through the "zombies" list in order to find the closest one to its own position.
        - Once the closest zombie has been found, the human will run away from that zombie, the direction is decided at random according to an interval found in AllUnit.cs GetMoveDir()
        - The only real difference between the Zombie and Human movement is that Zombies will run toward Humans wheras Humans will run away from Zombies.
        - Both zombie and Humans use the same GetMoveDir function except that the return that is passed to make it moved are different

    3) Who has a further detection range Humans or Zombies?
        - Zombies have longer detection range as we can confirm in Zombies.cs line 7 (DetectionRange of 6)
        - Other entities have a detection range of 5 and can be found in AIUnit.cs line 7

    4) How do zombies pick thier targets to follow?
        - Zombies keep a list of all the Humans on the map
        - If the "includePlayer" parameter is set to true (Zombies.cs line 22), it will also add the player in this list as a potential target
        - It will iterate through the list and compare the distance by calculating the SqrtMagnitude between himself minus the position of the human
        - If the distance is lower than "float.MaxValue", it will decide that this distance is the closest distance and the function will return the closestHuman for the Zombie to chase.

    5) Explain the use of the out keyword and bool return type in FindClosestTarget. Why do you assume that design was used?
        - Out is used in order to return additional information in the event that we need to output more than 1 info using a single function.
        - out Vector2 targetPos is used to provide the position of the target that the Human will run from and Zombie will run toward.
        - Depending on the case, it will also output a boolean statement to confirm if a target was found (true) or if no target was found (false)
        - If a target is found, the targetPos will be passed on and the Zombie/Human will behave accordingly
        - If no target is found, a new movement position will be generated after a certain amount of time so the humans/zombies will always be moving randomly until a target is found.
    
    New Features
    -Make A HUD that shows the amount of ammo by showing pictures of ammo in a Horizontal layout group
    -Make the HUD showcase the number of humans and zombies as text













     */
}
