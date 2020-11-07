using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    /*

    Guillaume Pelletier

    [Bug/Balance Fixes]
    //Fix the following issues in the game
    1) The walls are invisible, make them visible again [Fixed]
    2) Everything is shoved outside the screen when the game starts, fix that issue. [Fixed]
    3) Bullets do not seem to affect zombies [Fixed]
    4) The code that stops zombies and humans from spawning in walls seems to be bugged [Fixed]
    5) Set number of humans to spawn to 100 [Fixed]
   

    [Research]
    //Awnser the following questions with enough detail to explain to someone who hasn't seen the game or code yet
    1) How and where is the animations for the different unit types controlled, both in code and editor? 
    For example, there is no animation code in Player, yet it has different animations than Zombie
    
        Code side Animation is handled in the function UpdateAnimator() of Unit.cs which UnitManager.cs and PlayerManager.cs call using the function UpdateUnit() 
        Editor Animations are stored in Assets/Resources/Animations and are controlled by there repsective animation controller Player and Zombie
    

    2) Explain the flow of the movement system of the Humans? At what point does the movement calculation differ from Zombies?

        Humans will move away from Zombies while Zombies will move towards Humans and Player.
        AI Movment is done in GetMoveDir() of AIUnit.cs. The function FindClosestTarget() is overridden in Humans and Zombies. 
        Humans find the closest Zombie with GetClosestZombieToPoint() and then moves away from it.

    
    3) Who has a further detection range Humans or Zombies?

        Zombies with protected override float detectionRange => 6 in Zombies.cs
        To Humans protected virtual float detectionRange => 5 in AIUnit.cs.

    
    4) How do zombies pick thier targets to follow?

        In GetClosestHumanToPoint() that has includePlayer set to true in UnitManager.cs. 
        Gets a list of Humans and Player in its detection radius and moves towards the closest Human unit.
    
    
    5) Explain the use of the out keyword and bool return type in FindClosestTarget. Why do you assume that design was used?

        Variable out targetPos is the position Vector of the the target in the unit’s radius or a Vector2.zero. 
        Returns true when a detection is made and false when no unit was found.


    [New Features]
    -Make A HUD that shows the amount of ammo by showing pictures of ammo in a Horizontal layout group
    -Make the HUD showcase the number of humans and zombies as text
     */
}
