using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Unity.Logging;

public class Planet : MonoBehaviour
{
    public string planetName;
    public GameObject planetInterface;
    private GameObject myInterfaceWindow = null;
    private TextMeshProUGUI myNameText = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (myInterfaceWindow != null) 
        { 
            // update the text with our name if it's null
            if (myNameText != null)
            {  myNameText.text = planetName; }
        }
        
    }

    // when clicked, open the system's UI
    void OnMouseDown()
    {
        Log.Debug("Clicked system: " + planetName);

        // check if the interface window already exists. if it does, do nothing
        if (myInterfaceWindow != null) 
        {
            Log.Debug("Doing nothing because the window already exists");
            return; 
        }

        // find the game ui/canvas
        GameObject uiCanvas = GameObject.Find("Canvas");

        // add the planet details screen to the canvas
        myInterfaceWindow = Instantiate(planetInterface, uiCanvas.transform);
        myNameText = GameObject.Find("PlanetName").transform.GetComponent<TextMeshProUGUI>();
    }
}
