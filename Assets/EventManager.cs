using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    [SerializeField]
    public UnityEvent birdDeadEvent;
    [SerializeField]
    public UnityEvent scoreUpEvent;

    public void EmitBirdDeadEvent()
    {
        if (birdDeadEvent == null)
        {
            return;
        }

        birdDeadEvent.Invoke();
        Debug.Log("birdDeadEvent emitted");
    }

    public void EmitScoreUpEvent()
    {
        if (scoreUpEvent == null)
        {
            return;
        }

        scoreUpEvent.Invoke();
        Debug.Log("scoreUpEvent emitted");
    }
}
