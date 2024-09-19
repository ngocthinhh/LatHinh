using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    [Header("Home")]
    [SerializeField] private Button startBtn;

    [Header("InGame")]
    [SerializeField] private Button inGameToHomeBtn;
    [SerializeField] private Button pauseBtn;
    [SerializeField] private TextMeshProUGUI timeText;
    public TextMeshProUGUI TimeText => timeText;
    
    [Header("Win")]
    [SerializeField] private Button winToHomeBtn;
    [SerializeField] private TextMeshProUGUI timeResultText;
    public TextMeshProUGUI TimeResultText => timeResultText;

    [Header("Lose")]
    [SerializeField] private Button loseToHomeBtn;
    
    [Header("Pause")]
    [SerializeField] private Button continueBtn;
    
    public void SetUpBtn()
    {
        // Start
        startBtn.onClick.AddListener(() =>
        {
            MusicManager.Instance.PlaySound(MusicManager.Instance.ClickSource, MusicManager.Instance.ClickSound);
            MusicManager.Instance.PlaySound(MusicManager.Instance.BackgroundSource, MusicManager.Instance.BackgroundSound);
            ObjectValueManager.Instance.SetUp();
            TimeManager.Instance.StartTime();
            ObjectValueManager.Instance.SetBlock(false);
            PageManager.Instance.SwitchPage(PageManager.PageState.InGame);
        });

        // Win
        winToHomeBtn.onClick.AddListener(() =>
        {
            MusicManager.Instance.PlaySound(MusicManager.Instance.ClickSource, MusicManager.Instance.ClickSound);
            MusicManager.Instance.StopSound(MusicManager.Instance.ResultNoticationSource);
            PageManager.Instance.SwitchPage(PageManager.PageState.Home);
        });

        // Lose
        loseToHomeBtn.onClick.AddListener(() =>
        {
            MusicManager.Instance.PlaySound(MusicManager.Instance.ClickSource, MusicManager.Instance.ClickSound);
            MusicManager.Instance.StopSound(MusicManager.Instance.ResultNoticationSource);
            PageManager.Instance.SwitchPage(PageManager.PageState.Home);
        });

        // Pause
        continueBtn.onClick.AddListener(() =>
        {
            MusicManager.Instance.PlaySound(MusicManager.Instance.ClickSource, MusicManager.Instance.ClickSound);
            MusicManager.Instance.ContinueSound(MusicManager.Instance.BackgroundSource);
            TimeManager.Instance.ContinueTime();
            ObjectValueManager.Instance.SetBlock(false);
            PageManager.Instance.SwitchPage(PageManager.PageState.InGame);
        });

        // InGame
        inGameToHomeBtn.onClick.AddListener(() =>
        {
            MusicManager.Instance.PlaySound(MusicManager.Instance.ClickSource, MusicManager.Instance.ClickSound);
            MusicManager.Instance.StopSound(MusicManager.Instance.BackgroundSource);
            PageManager.Instance.SwitchPage(PageManager.PageState.Home);
        });
        pauseBtn.onClick.AddListener(() =>
        {
            MusicManager.Instance.PlaySound(MusicManager.Instance.ClickSource, MusicManager.Instance.ClickSound);
            MusicManager.Instance.PauseSound(MusicManager.Instance.BackgroundSource);
            TimeManager.Instance.PauseTime();
            ObjectValueManager.Instance.SetBlock(true);
            PageManager.Instance.SwitchPage(PageManager.PageState.Pause);
        });
    }

    public void ShowTimeWin()
    {
        int minute = (int)TimeManager.Instance.GetTime() / 60;
        int second = (int)TimeManager.Instance.GetTime() % 60;
        string text = string.Format("{0:00}:{1:00}", minute, second);
        TimeResultText.text = text;
    }
}
