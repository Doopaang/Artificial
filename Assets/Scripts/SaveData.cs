using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    private string path;

    [SerializeField]
    private List<Item> items;
    [HideInInspector]
    public List<bool> mapItemGain;

    public List<BookPos> bookPoses;
    private List<EItemType> bookSet;

    public EItemType usingItem = EItemType.NONE;

    [SerializeField]
    private List<Transform> transforms;

    private void Awake()
    {
        path = Path.Combine(Application.persistentDataPath, "Save");
        mapItemGain = new List<bool>();
        for (int count = 0; count < items.Count; count++)
        {
            mapItemGain.Add(false);
        }
        bookSet = new List<EItemType>();
        for (int count = 0; count < bookPoses.Count; count++)
        {
            bookSet.Add(EItemType.NONE);
        }
    }

    public void Save()
    {
        string str = "";

        #region __인벤토리__
        foreach (Item item in GameManager.Instance.Inventory.itemList)
        {
            str += item.itemType.ToString() + ',';
        }
        str += "\n";
        #endregion
        #region __현재 카메라__
        str += CameraSystem.Instance.cameras.FindIndex(0, (A) => { return CameraSystem.Instance.currentCamera == A; }).ToString() + "\n";
        #endregion
        #region __맵 아이템__
        foreach (bool boolean in mapItemGain)
        {
            str += boolean.ToString() + ",";
        }
        str += "\n";
        #endregion
        #region __책꽂이__
        foreach (EItemType type in bookSet)
        {
            str += type.ToString() + ",";
        }
        str += "\n";
        #endregion
        #region __사용 아이템__
        str += GameManager.Instance.Inventory.UsingItem.ToString() + "\n";
        #endregion
        #region __맵 오브젝트__
        #region __아이 그림__
        ChildPicture childPicture = FindObjectOfType<ChildPicture>();
        str += childPicture.changed.ToString() + "\n";
        #endregion
        #region __늑대인간 그림__
        WerewolfPicture werewolfPicture = FindObjectOfType<WerewolfPicture>();
        str += werewolfPicture.state.ToString() + "," + werewolfPicture.isGainCrescentMoon + "," + werewolfPicture.firstNightInteract + "\n";
        #endregion
        #region __대문 그림__

        #endregion
        #endregion
        #region __밤낮__
        str += GameManager.Instance.IsDaytime.ToString() + "\n";
        #endregion






        DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(path));
        if (!directoryInfo.Exists)
        {
            directoryInfo.Create();
        }

        FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
        StreamWriter writer = new StreamWriter(fileStream, System.Text.Encoding.Unicode);
        writer.Write(str);
        writer.Close();

        Debug.Log(str);
    }

    public void Load()
    {
        FileInfo fileInfo = new FileInfo(path);
        if (!fileInfo.Exists)
        {
            Save();
            return;
        }

        StreamReader reader = new StreamReader(path);
        if (reader == null)
        {
            Save();
            return;
        }

        string source = "";
        string[] values;

        #region __인벤토리__
        source = reader.ReadLine();
        values = source.Split(',', '\n');
        foreach (string str in values)
        {
            if (!string.IsNullOrEmpty(str))
            {
                GameManager.Instance.Inventory.GainItem((EItemType)System.Enum.Parse(typeof(EItemType), str), null, false);
            }
        }
        #endregion
        #region __현재 카메라__
        source = reader.ReadLine();
        values = source.Split(',', '\n');
        if (!string.IsNullOrEmpty(values[0]))
        {
            CameraSystem.Instance.MoveCamera(CameraSystem.Instance.cameras[int.Parse(values[0])]);
        }
        #endregion
        #region __맵 아이템__
        source = reader.ReadLine();
        values = source.Split(',', '\n');
        for (int count = 0; count < values.Length; count++)
        {
            LoadMapItem(values, count);
        }
        #endregion
        #region __책꽂이__
        source = reader.ReadLine();
        values = source.Split(',', '\n');
        for (int count = 0; count < values.Length; count++)
        {
            if (!string.IsNullOrEmpty(values[count]))
            {
                bookPoses[count].SetBook((EItemType)System.Enum.Parse(typeof(EItemType), values[count]));
            }
        }
        #endregion
        #region __사용 아이템__
        source = reader.ReadLine();
        values = source.Split(',', '\n');
        if (!string.IsNullOrEmpty(values[0]))
        {
            GameManager.Instance.Inventory.SetUsingItem((EItemType)System.Enum.Parse(typeof(EItemType), values[0]));
        }
        #endregion
        #region __맵 오브젝트__
        #region __아이 그림__
        source = reader.ReadLine();
        values = source.Split(',', '\n');
        if (bool.Parse(values[0]))
        {
            ChildPicture childPicture = FindObjectOfType<ChildPicture>();
            childPicture.ChangeToFullChildPicture();
        }
        #endregion
        #region __늑대인간 그림__
        source = reader.ReadLine();
        values = source.Split(',', '\n');
        WerewolfPicture werewolfPicture = FindObjectOfType<WerewolfPicture>();
        werewolfPicture.ChangePicture((EWerewolfPictureType)System.Enum.Parse(typeof(EWerewolfPictureType), values[0]), false);
        werewolfPicture.isGainCrescentMoon = bool.Parse(values[1]);
        werewolfPicture.firstNightInteract = bool.Parse(values[2]);
        #endregion
        #region __대문 그림__

        #endregion
        #endregion
        #region __밤낮__
        source = reader.ReadLine();
        values = source.Split(',', '\n');
        if (!string.IsNullOrEmpty(values[0]))
        {
            GameManager.Instance.IsDaytime = !bool.Parse(values[0]);
        }
        #endregion






        reader.Close();
    }

    #region __맵 아이템__
    public void SaveMapItem(MonoBehaviour mapItem)
    {
        int index = items.FindIndex((A) => { return A.itemType == mapItem.GetComponent<Item>().itemType; });
        mapItemGain[index] = true;
    }
    private void LoadMapItem(string[] str, int num)
    {
        if (!string.IsNullOrEmpty(str[num]) &&
            bool.Parse(str[num]))
        {
            items[num].gameObject.SetActive(false);
            mapItemGain[num] = true;
        }
    }
    #endregion

    #region __책꽂이__
    public void SaveBookPos(BookPos pos, EItemType type)
    {
        int index = bookPoses.FindIndex((A) => { return A == pos; });
        bookSet[index] = type;
    }
    #endregion
}
