using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [02/20/2024]
 * [A timer that plays before a race starts then publishes the START race event]
 */

public class CountdownTimer : MonoBehaviour
{
    //the desired countdown time of the timer
    private float currentTime;
    private float duration = 3f;

    private void OnEnable()
    {
        //Add/Subscribe the StartTimer method to the COUNTDOWN race event
        RaceEventBus.Subscribe(RaceEventType.COUNTDOWN, StartTimer);
    }

    private void OnDisable()
    {
        //Remove/Unsubscribe the StartTimer method from the COUNTDOWN race event
        RaceEventBus.Unsubscribe(RaceEventType.COUNTDOWN, StartTimer);
    }

    /// <summary>
    /// Starts the race countdown timer
    /// </summary>
    private void StartTimer()
    {
        //Call the Countdown coroutine
        StartCoroutine(Countdown());
    }

    /// <summary>
    /// A coroutine that counts down from the desired countdown duration then publishes the START race event
    /// </summary>
    /// <returns> The time in seconds between each countdown interval </returns>
    private IEnumerator Countdown()
    {
        //set the currentTime equal to the duration
        currentTime = duration;

        //while the currentTime is greater than a value of 0
        while (currentTime > 0)
        {
            //wait 1 second then decrement currentTime by 1
            yield return new WaitForSeconds(1f);
            currentTime--;
        }

        //when the current time is == 0, publish the START race event
        RaceEventBus.Publish(RaceEventType.START);
    }

    /// <summary>
    /// TESTING PURPOSES ONLY ( DO NOT USE IN PRODUCTION CODE ) EXTREMELY INEFFICIENT
    /// </summary>
    private void OnGUI()
    {
        //set the GUI color to green
        GUI.color = Color.green;

        //Display the timer
        GUI.Label(new Rect(125, 0, 100, 20), "Countdown: " + currentTime);
    }
}
