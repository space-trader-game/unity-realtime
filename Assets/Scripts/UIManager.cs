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
        Log.Debug("Object clicked: " + @event.clickedPlanet);

        // delete all the children of the ObjectDetails panel
        foreach (Transform child in objectDetails.transform)
        {
            Log.Debug("Deleting UI item: " + child);
            GameObject.Destroy(child.gameObject);
        }

        Planet clickedPlanet = @event.clickedPlanet;

        // add the object's details panel
        PlanetDetails planetDetails = Instantiate(clickedPlanet.planetDetails, objectDetails.transform);
        planetDetails.InitializeDetails(clickedPlanet);
    }

}
