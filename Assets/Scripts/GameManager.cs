using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Logging;
using Unity.Logging.Sinks;

using TMPro;

using EventBus;
using GameEvents.TimeTickSystem;

public class GameManager : MonoBehaviour
{
    private int starDate;        
    private TextMeshProUGUI starDateText;
    private TextMeshProUGUI currentMoneyText;

    private int currentMoney;
    EventBinding<TimeTickEvent> _onTimeTick;

    // Start is called before the first frame update
    void Start()
    {
        // set the default log level
        Log.Logger = new Unity.Logging.Logger(new LoggerConfig().MinimumLevel.Debug()
            .WriteTo.UnityEditorConsole());

        // gamemanager should subscribe to the tick system and do something with ticks
        _onTimeTick = new EventBinding<TimeTickEvent>(TimeTickSystem_OnTick);

        // get the stardate text
        starDateText = GameObject.Find("Stardate").GetComponent<TextMeshProUGUI>();
        currentMoneyText = GameObject.Find("Money").GetComponent<TextMeshProUGUI>();

        starDate = 0;
        starDateText.text = "Stardate: " + starDate;

        currentMoney = 1000000;
        currentMoneyText.text = "Money: " + currentMoney;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void TimeTickSystem_OnTick(TimeTickEvent @event)
    {
        Log.Verbose($"Processing tick: {@event.tick}");
        UpdateStardate(@event.tick);
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
