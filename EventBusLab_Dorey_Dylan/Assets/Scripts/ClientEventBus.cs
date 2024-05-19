using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [02/20/2024]
 * [Client event bus component]
 */

public class ClientEventBus : MonoBehaviour
{
    //enables/disables the start countdown button
    private bool isButtonEnabled;

    private void Start()
    {
        //add the HUDController, CountdownTimer, and BikeController to the client GameObject
        gameObject.AddComponent<HUDController>();
        gameObject.AddComponent<CountdownTimer>();
        gameObject.AddComponent<BikeController>();

        //enable the coutdown button
        isButtonEnabled = true;
    }

    private void OnEnable()
    {
        //Add/Subscribe the Resart method to the STOP race event
        RaceEventBus.Subscribe(RaceEventType.STOP, Restart);
    }

    private void OnDisable()
    {
        //Remove/Unsubscribe the Resart method from the STOP race event
        RaceEventBus.Unsubscribe(RaceEventType.STOP, Restart);
    }

    /// <summary>
    /// Restarts the countdown timer
    /// </summary>
    private void Restart()
    {
        //set countdown button to enabled
        //FILLER CODE FOR EVENT BUS DEMONSTRATION
        isButtonEnabled = true;
    }

    /// <summary>
    /// TESTING PURPOSES ONLY ( DO NOT USE IN PRODUCTION CODE ) EXTREMELY INEFFICIENT
    /// </summary>
    private void OnGUI()
    {
        //if the countdown button is enabled
        if(isButtonEnabled)
        {
            //Start Countdown button
            if(GUILayout.Button("Start Countdown"))
            {
                //if pressed, turn the button off and publish the COUNTDOWN race event
                isButtonEnabled = false;
                RaceEventBus.Publish(RaceEventType.COUNTDOWN);
            }
        }
    }
}
