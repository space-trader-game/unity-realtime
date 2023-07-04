using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Logging;

using EventBus;
using GameEvents.UIEventSystem;
using System;

namespace GameEvents.UIEventSystem
{

    public struct ClickedPlanetEvent : IEvent
    {
        public Planet clickedPlanet;
    }

}

public class UIManager : MonoBehaviour
{
    private GameObject objectDetails;

    EventBinding<ClickedPlanetEvent> _onClickedPlanetEvent;

    private void Awake()
    {
        _onClickedPlanetEvent = new EventBinding<ClickedPlanetEvent>(OnClickedPlanet);

        // find the object details empty on the canvas
        objectDetails = GameObject.Find("ObjectDetails");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // When a planet is clicked, its details screen should be displayed
    private void OnClickedPlanet(ClickedPlanetEvent @event)
    {
        // find any details panels and destroy them
        GameObject[] panels = GameObject.FindGameObjectsWithTag("DetailsPanel");

        foreach (GameObject panel in panels) 
        {
            Log.Verbose($"Deleting panel {panel.name}/{panel.GetInstanceID()}");
            Destroy(panel);
        }

        Planet clickedPlanet = @event.clickedPlanet;

        // add the object's details panel
        Log.Verbose($"Instantiating panel for {clickedPlanet.planetName}");
        PlanetDetails planetDetails = Instantiate(clickedPlanet.planetDetails, objectDetails.transform);

        Log.Verbose($"Initializing panel for {clickedPlanet.planetName}");
        planetDetails.InitializeDetails(clickedPlanet, planetDetails.transform);
    }

}
