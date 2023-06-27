using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int starDate;        
    private TextMeshProUGUI starDateText;

    private int currentMoney;

    // Start is called before the first frame update
    void Start()
    {
        // gamemanager should subscribe to the tick system and do something with ticks
        TimeTickSystem.OnTick += TimeTickSystem_OnTick;
        // get the stardate text
        starDateText = GameObject.Find("Stardate").GetComponent<TextMeshProUGUI>();

        starDate = 0;
        starDateText.text = "Stardate: " + starDate;

        currentMoney = 1000000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TimeTickSystem_OnTick(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        Debug.Log("Current tick: " + e.tick);
        UpdateStardate(e.tick);
    }

    private void UpdateStardate(int tick)
    {
        // every 10 ticks, update stardate
        if (tick % 10 == 0)
        {
            starDate++;
            starDateText.text = "Stardate: " + starDate;
        }
    }

}
