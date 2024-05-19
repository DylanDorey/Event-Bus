using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [02/20/2024]
 * [Event Bus for Race events that Subscribes, Unsubscribes, and Publishes unity events]
 */

public class RaceEventBus
{
    //Initialize a dictionary of race events
    private static readonly IDictionary<RaceEventType, UnityEvent> Events = new Dictionary<RaceEventType, UnityEvent>();

    /// <summary>
    /// Adds a listener/method to a specific race event
    /// </summary>
    /// <param name="eventType"> the specific race event </param>
    /// <param name="listener"> the function/method getting added to the race event</param>
    public static void Subscribe(RaceEventType eventType, UnityAction listener)
    {
        //the event being subscribed to
        UnityEvent thisEvent;

        //if the function is assigned to the specific unity race event
        if (Events.TryGetValue(eventType, out thisEvent))
        {
            //add it as a listener
            thisEvent.AddListener(listener);
        }
        else
        {
            //otherwise it is a new listener
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Events.Add(eventType, thisEvent);
        }
    }

    /// <summary>
    /// Removes a listener/method from a specific race event
    /// </summary>
    /// <param name="type"> the specific race event </param>
    /// <param name="listener"> the function/method getting removed from the race event </param>
    public static void Unsubscribe(RaceEventType type, UnityAction listener)
    {
        //the event being unsubscribed from
        UnityEvent thisEvent;

        //if the function is equal to the race event being removed
        if (Events.TryGetValue(type, out thisEvent))
        {
            //remove the function from the list of listeners
            thisEvent.RemoveListener(listener);
        }
    }

    /// <summary>
    /// Publishes a specified race event globally
    /// </summary>
    /// <param name="type"> the specific race event </param>
    public static void Publish(RaceEventType type)
    {
        //the event being published
        UnityEvent thisEvent;

        //If the function is equal to the race event being published
        if (Events.TryGetValue(type, out thisEvent))
        {
            //Invoke the function for the race event
            thisEvent.Invoke();
        }
    }
}
