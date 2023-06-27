using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSystem : MonoBehaviour
{
    public string systemName;

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
        Debug.Log("Clicked system: " + systemName);
    }
}
