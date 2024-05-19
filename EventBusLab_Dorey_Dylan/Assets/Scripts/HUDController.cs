using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [02/20/2024]
 * [Contols all HUD/UI race elements]
 */

public class HUDController : MonoBehaviour
{
    //determines if the display is enabled/disabled
    private bool isDisplayOn;

    private void OnEnable()
    {
        //Add/Subscribe the DisplayHUD method to the START race event
        RaceEventBus.Subscribe(RaceEventType.START, DisplayHUD);
    }

    private void OnDisable()
    {
        //Remove/Unsubscribe the DisplayHUD method from the START race event
        RaceEventBus.Unsubscribe(RaceEventType.START, DisplayHUD);
    }

    /// <summary>
    /// Turns the display/UI on
    /// </summary>
    private void DisplayHUD()
    {
        //set isDisplayOn to true
        //FILLER CODE FOR EVENT BUS DEMONSTRATION
        isDisplayOn = true;
    }

    /// <summary>
    /// TESTING PURPOSES ONLY ( DO NOT USE IN PRODUCTION CODE ) EXTREMELY INEFFICIENT
    /// </summary>
    private void OnGUI()
    {
        //if the display is on
        if (isDisplayOn)
        {
            //stop race button
            if(GUILayout.Button("Stop Race"))
            {
                //if pressed, turn the display/UI off and publish the STOP race event
                isDisplayOn = false;
                RaceEventBus.Publish(RaceEventType.STOP);
            }
        }
    }
}
