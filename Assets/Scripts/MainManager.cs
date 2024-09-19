using UnityEngine;

public class MainManager : MonoBehaviour
{
    public PageManager PageManager;
    public TimeManager TimeManager;
    public UIManager UIManager;
    public ObjectValueManager ObjectValueManager;
    public MusicManager MusicManager;
    
    private void Awake()
    {
        PageManager.Instance = this.PageManager;
        TimeManager.Instance = this.TimeManager;
        UIManager.Instance = this.UIManager;
        ObjectValueManager.Instance = this.ObjectValueManager;
        MusicManager.Instance = this.MusicManager;

        //

        UIManager.SetUpBtn();
        PageManager.SwitchPage(PageManager.PageState.Home);
    }

    private void Update()
    {
        if (TimeManager.IsTiming && TimeManager.TimeCurrent > 0)
        {
            TimeManager.TimeCurrent -= Time.deltaTime;
            int minute = (int)TimeManager.TimeCurrent / 60;
            int second = (int)TimeManager.TimeCurrent % 60;
            //float milisecond = TimeManager.TimeCurrent * 100 % 100;
            string text = string.Format("{0:00}:{1:00}", minute, second);
            UIManager.Instance.TimeText.text = text;


            if (TimeManager.TimeCurrent <= 0)
            {
                TimeManager.TimeCurrent = 0;
                PageManager.Instance.SwitchPage(PageManager.PageState.Lose);
            }
        }
    }
}
