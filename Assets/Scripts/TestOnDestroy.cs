using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Logging;

public class TestOnDestroy : MonoBehaviour
{
    private void OnDestroy()
    {
        Log.Debug($"Button destroy {name} {GetInstanceID()}");
        
    }
}
