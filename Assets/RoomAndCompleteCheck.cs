using UnityEngine;

public class RoomAndCompleteCheck : MonoBehaviour
{
    public bool inDefaultScene = true;
    public bool gameEnded = false;

    public GameObject timerObject;
    public GameObject IRLroom;
    public GameObject VideoTower;

 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        gameEnded = timerObject.GetComponent<TimerCountdown>().gameHasEnded;

        if (IRLroom.activeInHierarchy && !VideoTower.activeInHierarchy)
        {
            inDefaultScene = true;
        }
        else if (!IRLroom.activeInHierarchy && VideoTower.activeInHierarchy)
        {
            inDefaultScene = false;
        }
    }
}
