// https://www.youtube.com/watch?v=NFvmfoRnarY
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTickSystem : MonoBehaviour
{
    // allow other things to subscribe to the tick event
    public class OnTickEventArgs : EventArgs 
    {
        public int tick;
    }

    public static event EventHandler<OnTickEventArgs> OnTick;

    // TODO: This probably needs to be adjustable for game speed
    private const float TICK_TIMER_MAX = 0.2f; // 200ms or 5 ticks per second
    private int tick; // current tick
    private float tickTimer; // store the time

    private void Awake()
    {
        // initialize to zero
        tick = 0;
    }

    private void Update() 
    {
        tickTimer += Time.deltaTime;
        if (tickTimer > TICK_TIMER_MAX) {
            tickTimer -= TICK_TIMER_MAX;
            tick++;

            // check for subscribers
            if (OnTick != null)
            {
                OnTick(this, new OnTickEventArgs { tick = tick }); // pass the tick to the subscribers
            }
        }
    }
}
