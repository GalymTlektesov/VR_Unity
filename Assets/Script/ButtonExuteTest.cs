using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;

public class ButtonExuteTest : MonoBehaviour
{
    private GameObject stopButton, startButton;
    private bool on = false;
    private float timer = 5.0f;

    void Start()
    {
        startButton = GameObject.Find("StartButton");
        stopButton = GameObject.Find("StopButton");
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0.0f)
        {
            on = !on;
            timer = 5.0f;

            PointerEventData data = new PointerEventData(EventSystem.current);
            if (on)
            {
                ExecuteEvents.Execute<IPointerClickHandler>(startButton, data, ExecuteEvents.pointerClickHandler);
            }
            else
            {
                ExecuteEvents.Execute<IPointerClickHandler>(stopButton, data, ExecuteEvents.pointerClickHandler);
            }
        }
    }
}
