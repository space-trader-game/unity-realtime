using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Logging;

using EventBus;

public class BuildImprovementButton : MonoBehaviour
{

    Planet myPlanet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(Planet thePlanet)
    {
        myPlanet = thePlanet;
        Log.Debug($"My planet is {thePlanet.name}/{thePlanet}");
    }

    public void OnButtonClicked() 
    {
    }
}
