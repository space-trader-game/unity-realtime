using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Logging;

using EventBus;
using TMPro;

public class PlanetDetails : MonoBehaviour
{
    Planet myPlanet;
    public GameObject buildImprovementButton;
    GameObject planetDetailsPanel;

    // Start is called before the first frame update
    void Start()
    {
        Log.Debug($"Planet {myPlanet.planetName} has {myPlanet.improvementSlots} slots");
        UpdatePlanetNameText();
        planetDetailsPanel = GameObject.Find("PlanetDetailsPanel");

        for ( int i = 0; i < myPlanet.improvementSlots;  i++ )
        {
            Log.Debug($"Adding improvement button {i}");
            Instantiate(buildImprovementButton, planetDetailsPanel.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlanetNameText();
    }

    public void InitializeDetails(Planet thePlanet)
    {
        myPlanet = thePlanet;
    }

    void UpdatePlanetNameText()
    {
        TextMeshProUGUI planetName = GameObject.Find("PlanetName").GetComponent<TextMeshProUGUI>();
        planetName.text = myPlanet.planetName; 
    }
}
