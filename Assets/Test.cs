using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    /*
      The game is on the SampleScene scene.
     

    Bug/Balance Fixes
    //Fix the following issues in the game
    1) The walls are invisible, make them visible again
    2) Everything is shoved outside the screen when the game starts, fix that issue.
    3) Bullets do not seem to affect zombies
    4) The code that stops zombies and humans from spawning in walls seems to be bugged
    5) Set number of humans to spawn to 100
   

    Research
    //Awnser the following questions with enough detail to explain to someone who hasn't seen the game or code yet
    1) How and where is the animations for the different unit types controlled, both in code and editor? 
        For example, there is no animation code in Player, yet it has different animations than Zombie

    So they are both done at the Unit layer class of inheritance for both objects, by being given thier move direction which modifies the HorzAxis and VertAxis parameters in the statemachine.
    They both have different animation clips played in thier state machines, but both use the same parameters.


    2) Explain the flow of the movement system of the Humans? At what point does the movement calculation differ from Zombies?

    So human movement is done inside Unit.cs Move function, the direction the human moves comes from an override of the GetMoveDir() both from  AIUnit.cs and Human.cs.
    Unit::GetMoveDir => AIUnit::GetMoveDir => Human::GetMoveDir

    AIUnit::GetMoveDir
    Finds the closest target and checks distance, if it is close enough, it returns a vector towards that target

    Human::GetMoveDir
    Multiplies the direction vector from AIUnit::GetMoveDir by *-1 in order to run away from the target instead

    Zombies and humans both use AIUnit to calculate direction, they differ in thier function "FindClosestTarget"
    Zombies check for closest human, and humans check for closest zombies



    3) Who has a further detection range Humans or Zombies?
    Zombie detection range is 6
    Human detection range is 5

    4) How do zombies pick thier targets to follow?
    Zombies use an override of the function FindClosestTarget in Zombie.cs
    They call a function in UnitManager called GetClosestHumanToPoint
    It searches through all humans and players to find the closest one.


    5) Explain the use of the out keyword and bool return type in FindClosestTarget. Why do you assume that design was used?
    So the out keyword is used to return a variable. Often used in functions that have more than one value to return.
    so the bool means if we found a target or not
    the out vector is the position of the target we found, however it will return (0,0) if a target was not found.


    New Features
    -Make A HUD that shows the amount of ammo by showing pictures of ammo in a Horizontal layout group
    -Make the HUD showcase the number of humans and zombies as text
    -Make a text appear that says "Gameover" and destroy the player. Then zoom out to show more of the map













     */
}
