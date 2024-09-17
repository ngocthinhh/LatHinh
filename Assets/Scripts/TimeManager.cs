using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;
    
    [SerializeField] private float maxTime = 60 * 20;
    public float MaxTime => maxTime;
    
    [SerializeField] private float timeCurrent = 0f;
    public float TimeCurrent
    {
        get { return timeCurrent; }
        set { timeCurrent = value; }
    }

    [SerializeField] private bool isTiming = false;
    public bool IsTiming => isTiming;
    
    public float GetTime()
    {
        return timeCurrent;
    }

    public void ResetTime()
    {
        timeCurrent = 0;
        isTiming = false;
    }

    public void StartTime()
    {
        timeCurrent = maxTime;
        isTiming = true;
    }

    public void StopTime()
    {
        isTiming = false;
    }

    public void PauseTime()
    {
        Time.timeScale = 0;
    }

    public void ContinueTime()
    {
        Time.timeScale = 1;
    }
}
