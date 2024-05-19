using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [02/20/2024]
 * [The user controlled bike controller]
 */

public class BikeController : MonoBehaviour
{
    //the status of the bike
    private string status;

    private void OnEnable()
    {
        //Add/Subscribe the StartBike method to the START race event
        RaceEventBus.Subscribe(RaceEventType.START, StartBike);

        //Add/Subscribe the StopBike method to the STOP race event
        RaceEventBus.Subscribe(RaceEventType.STOP, StopBike);
    }

    private void OnDisable()
    {
        //Remove/Unsubscribe the StartBike method from the START race event
        RaceEventBus.Unsubscribe(RaceEventType.START, StartBike);

        //Remove/Unsubscribe the StopBike method from the STOP race event
        RaceEventBus.Unsubscribe(RaceEventType.STOP, StopBike);
    }

    /// <summary>
    /// Starts the bike
    /// </summary>
    private void StartBike()
    {
        //set the status of the bike to started
        //FILLER CODE FOR EVENT BUS DEMONSTRATION
        status = "Started";
    }

    /// <summary>
    /// Stops the bike
    /// </summary>
    private void StopBike()
    {
        //set the status of the bike to stopped
        //FILLER CODE FOR EVENT BUS DEMONSTRATION
        status = "Stopped";
    }

    /// <summary>
    /// TESTING PURPOSES ONLY ( DO NOT USE IN PRODUCTION CODE ) EXTREMELY INEFFICIENT
    /// </summary>
    private void OnGUI()
    {
        //set the GUI color to green
        GUI.color = Color.green;

        //Display the status of the bike
        GUI.Label(new Rect(10, 60, 200, 20), "Bike Status: " + status);
    }
}

