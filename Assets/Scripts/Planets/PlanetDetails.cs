using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Logging;

using EventBus;
using TMPro;

public class PlanetDetails : MonoBehaviour
{
    Planet myPlanet;
    public BuildImprovementButton buildImprovementButton;
    Transform planetDetailsPanelTransform;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlanetNameText();
    }

    public void InitializeDetails(Planet thePlanet, Transform myTransform)
    {
        Log.Verbose($"Initializing with {thePlanet}");
        myPlanet = thePlanet;

        Log.Verbose($"Planet {myPlanet.planetName} has {myPlanet.improvementSlots} slots");
        UpdatePlanetNameText();

        planetDetailsPanelTransform = myTransform.Find("PlanetDetailsPanel");
        Log.Verbose($"PlanetDetailsPanel is {planetDetailsPanelTransform} {planetDetailsPanelTransform.GetInstanceID()}");

        for ( int i = 0; i < myPlanet.improvementSlots;  i++ )
        {
            Log.Verbose($"Adding improvement button {i}");
            Instantiate(buildImprovementButton, planetDetailsPanelTransform);
            //BuildImprovementButton theButton = Instantiate(buildImprovementButton, planetDetailsPanelTransform);
            //theButton.Initialize(myPlanet);
        }
    }

    void UpdatePlanetNameText()
    {
        TextMeshProUGUI planetName = GameObject.Find("PlanetName").GetComponent<TextMeshProUGUI>();
        planetName.text = myPlanet.planetName; 
    }
}
