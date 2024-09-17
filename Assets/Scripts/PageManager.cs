using UnityEngine;
using UnityEngine.Events;

public class PageManager : MonoBehaviour
{
    public enum PageState
    {
        Home,
        InGame,
        Win,
        Lose,
        Pause
    }
    public PageState Page = PageState.Home;
    public static PageManager Instance;
    
    [Header("Home")]
    [SerializeField] private GameObject homePage;

    [Header("InGame")]
    [SerializeField] private GameObject inGamePage;
    
    [Header("Win")]
    [SerializeField] private GameObject winPage;
    
    [Header("Lose")]
    [SerializeField] private GameObject losePage;
    
    [Header("Pause")]
    [SerializeField] private GameObject pausePage;
    
    public void SwitchPage(PageState newState)
    {
        Page = newState;
        switch (Page)
        {
            case PageState.Home:
                CloseAllPage();
                TimeManager.Instance.ResetTime();
                ObjectValueManager.Instance.Clear();
                homePage.gameObject.SetActive(true);
                break;
            case PageState.InGame:
                CloseAllPage();
                TimeManager.Instance.ContinueTime();
                inGamePage.gameObject.SetActive(true);
                break;
            case PageState.Win:
                CloseAllPage();
                TimeManager.Instance.StopTime();
                UIManager.Instance.ShowTimeWin();
                winPage.gameObject.SetActive(true);
                break;
            case PageState.Lose:
                CloseAllPage();
                TimeManager.Instance.StopTime();
                losePage.gameObject.SetActive(true);
                break;
            case PageState.Pause:
                pausePage.gameObject.SetActive(true);
                break;
        }
    }

    public void CloseAllPage()
    {
        homePage.gameObject.SetActive(false);
        inGamePage.gameObject.SetActive(false);
        winPage.gameObject.SetActive(false);
        losePage.gameObject.SetActive(false);
        pausePage.gameObject.SetActive(false);
    }
}
