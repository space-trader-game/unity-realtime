using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Unity.Logging;

using EventBus;
using GameEvents.UIEventSystem;

public class Planet : MonoBehaviour
{
    public PlanetDetails planetDetails;

    // TODO: should these be handled with some kind of interface?
    // TODO: shouldn't be public - get and private set?
    public int improvementSlots;

    // TODO: probably shouldn't be public?
    public string planetName;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    // when clicked, open the system's UI
    void OnMouseDown()
    {
        Log.Debug("Clicked system: " + planetName);

        EventBus<ClickedPlanetEvent>.Raise(new ClickedPlanetEvent() { clickedPlanet = this }); ;
    }
}
