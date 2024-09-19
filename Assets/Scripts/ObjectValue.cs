using UnityEngine;
using UnityEngine.UI;

public class ObjectValue : MonoBehaviour
{
    public Sprite BackImage;
    public Sprite FrontImage;
    public Sprite DoneImage;

    public Button ChoseBtn;
    public Image ShowImage;

    private ObjectValueManager objectValueManager;

    public void SetUp(ObjectValueManager objectValueManager)
    {
        this.objectValueManager = objectValueManager;

        ChoseBtn = GetComponent<Button>();
        ShowImage = GetComponent<Image>();

        ChoseBtn.onClick.AddListener(() =>
        {
            Open();
            MusicManager.Instance.PlaySound(MusicManager.Instance.ClickSource, MusicManager.Instance.ClickSound);
        });
    }

    void Open()
    {
        ChoseBtn.interactable = false;
        ShowImage.sprite = FrontImage;
        objectValueManager.Compare(this);
    }

    public void Close()
    {
        ShowImage.sprite = BackImage;
        ChoseBtn.interactable = true;
    }

    public void Done()
    {
        ShowImage.sprite = DoneImage;
        ChoseBtn.interactable = false;
    }

    public void Restart(Sprite newFrontImage, Sprite newBackImage, Sprite newDoneImage)
    {
        FrontImage = newFrontImage;
        BackImage = newBackImage;
        DoneImage = newDoneImage;
    }
}
