using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Logging;

using EventBus;
using GameEvents.TimeTickSystem;


public class ConstructionManager : MonoBehaviour
{

    EventBinding<TimeTickEvent> _onTimeTick;

    // Start is called before the first frame update
    void Start()
    {
        _onTimeTick = new EventBinding<TimeTickEvent>(TimeTickSystem_OnTick);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TimeTickSystem_OnTick(TimeTickEvent @event)
    {
        Log.Verbose($"Processing tick: {@event.tick}");
    }
}
