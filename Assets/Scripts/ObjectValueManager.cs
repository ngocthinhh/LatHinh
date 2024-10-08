using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ObjectValueManager : MonoBehaviour
{
    public static ObjectValueManager Instance;

    [SerializeField] private GameObject block;
    [SerializeField] private Sprite BackImage;
    [SerializeField] private Sprite DoneImage;
    [SerializeField] private List<Sprite> FrontImageAssetList = new List<Sprite>();
    [SerializeField] private List<Sprite> FrontImageList = new List<Sprite>();
    [SerializeField] private List<ObjectValue> ObjectValueList = new List<ObjectValue>();

    [SerializeField] private ObjectValue valueOne;
    [SerializeField] private ObjectValue valueTwo;

    [SerializeField] private int row = 4;
    [SerializeField] private int col = 5;
    [SerializeField] private GameObject colObject;
    [SerializeField] private GameObject rowObject;
    [SerializeField] private GameObject containObject;
    
    public void Clear()
    {
        ObjectValueList.Clear();
        foreach (Transform child in containObject.transform)
        {
            Destroy(child.gameObject);
        }

        valueOne = null;
        valueTwo = null;
    }

    public void SetUp()
    {
        //
        for (int j = 0; j < row; j++)
        {
            GameObject rObject = Instantiate(rowObject, containObject.transform);
            for (int i = 0; i < col; i++)
            {
                Instantiate(colObject, rObject.transform);
            }
        }

        //
        ObjectValue[] objectValues = containObject.GetComponentsInChildren<ObjectValue>();
        ObjectValueList.AddRange(objectValues);

        // Get Random From Asset
        List<Sprite> assetList = new List<Sprite>(FrontImageAssetList);
        FrontImageList.Clear();
        for (int i = 0; i < 10; i++)
        {
            Sprite sprite = assetList[Random.Range(0, assetList.Count)];
            assetList.Remove(sprite);
            FrontImageList.Add(sprite);
        }

        //
        List<Sprite> spriteList = new List<Sprite>();
        int indexFrontImageList = 0;
        bool isDuplicate = false;
        foreach (ObjectValue value in ObjectValueList)
        {
            spriteList.Add(FrontImageList[indexFrontImageList]);

            if (!isDuplicate)
            {
                isDuplicate = !isDuplicate;
                continue;
            }

            isDuplicate = !isDuplicate;
            indexFrontImageList++;
            if (indexFrontImageList == FrontImageList.Count)
            {
                indexFrontImageList = 0;
            }
        }


        //
        foreach (ObjectValue value in ObjectValueList)
        {
            Sprite sprite = spriteList[Random.Range(0, spriteList.Count)];
            spriteList.Remove(sprite);
            value.Restart(sprite, BackImage, DoneImage);
            value.SetUp(this);
            value.Close();
        }
    }

    public async void Compare(ObjectValue value)
    {
        if (valueOne == null)
        {
            valueOne = value;
            return;
        }
        else
        {
            block.SetActive(true);
            valueTwo = value;

            await Task.Delay(500);
            if (valueOne.FrontImage == valueTwo.FrontImage)
            {
                valueOne.Done();
                valueTwo.Done();

                ObjectValueList.Remove(valueOne);
                ObjectValueList.Remove(valueTwo);

                MusicManager.Instance.PlaySound(MusicManager.Instance.InGameNoticationSource, MusicManager.Instance.SuccesSound);
            }
            else
            {
                valueOne.Close();
                valueTwo.Close();

                MusicManager.Instance.PlaySound(MusicManager.Instance.InGameNoticationSource, MusicManager.Instance.FallSound);
            }

            valueOne = null;
            valueTwo = null;
            block.SetActive(false);

            //
            if ((row * col) % 2 == 0)
            {
                if (ObjectValueList.Count == 0)
                {
                    PageManager.Instance.SwitchPage(PageManager.PageState.Win);
                }
            }
            else
            {
                if (ObjectValueList.Count == 1)
                {
                    PageManager.Instance.SwitchPage(PageManager.PageState.Win);
                }

            }
        }
    }

    public void SetBlock(bool isBlock)
    {
        if (isBlock)
        {
            block.SetActive(true);
        }
        else
        {
            block.SetActive(false);
        }
    }
}
