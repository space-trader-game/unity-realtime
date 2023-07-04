using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Logging;

public class ClosePanel : MonoBehaviour
{
    // used as the reference for closing our panel when the close button is clicked
    public GameObject myPanel;

    public void OnClick()
    {
        Log.Debug($"Close button clicked");
        Destroy(myPanel);
    }
}
