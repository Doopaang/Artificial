using System.IO;
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
    private List<ReactInteraction> reacts;

    [SerializeField]
    private List<Drawer> drawers;
    [SerializeField]
    private List<CabinetDoor> cabinets;
    [SerializeField]
    private List<PuzzleDoor> doors;
    [SerializeField]
    private List<Lock> locks;
    [SerializeField]
    private List<DrawerDoor> drawerDoors;
    [SerializeField]
    private List<ColorPuzzleBox> colorPuzzles;

    private void Awake()
    {
        path = Path.Combine(Application.dataPath, "../Save/Save");
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

    private void Start()
    {
        Load();

        //SceneManager.sceneUnloaded += (A) => { Save(); };
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
        HousePicture housePicture = FindObjectOfType<HousePicture>();
        str += housePicture.state.ToString() + "," + housePicture.gateLocked.ToString() + "\n";
        #endregion
        #region __노랑 그림__
        ArtYellow artYellow = FindObjectOfType<ArtYellow>();
        str += artYellow.isFirst.ToString() + "," + artYellow.usedFlower.ToString() + "," + artYellow.usedKnife.ToString() + "," + artYellow.isFirstGreen.ToString() + "," + artYellow.isChanged.ToString() + "\n";
        #endregion
        #region __초록 그림__
        ArtGreen artGreen = FindObjectOfType<ArtGreen>();
        str += artGreen.isChanged.ToString() + "," + artGreen.isFirst.ToString() + "," + artGreen.isFlowerFirst.ToString() + "\n";
        #endregion
        #region __파랑 그림__
        ArtBlue artBlue = FindObjectOfType<ArtBlue>();
        str += artBlue.isChanged.ToString() + "," + artBlue.isFirst.ToString() + "," + artBlue.usedItem.ToString() + "\n";
        #endregion
        #region __빨강 그림__
        ArtRed artRed = FindObjectOfType<ArtRed>(true);
        str += artRed.isChanged.ToString() + "\n";
        #endregion
        #region __찢어진 빨강 그림__
        ShreddedRedCharacterPicture shreddedArtRed = FindObjectOfType<ShreddedRedCharacterPicture>(true);
        str += shreddedArtRed.isFirst.ToString() + "\n";
        #endregion
        #region __열쇠 자물쇠__
        LockForKey lockKey = FindObjectOfType<LockForKey>(true);
        str += lockKey.opened.ToString() + "\n";
        #endregion
        #region __파란버튼 퍼즐__
        BlueButtonBox blueButtonBox = FindObjectOfType<BlueButtonBox>(true);
        str += blueButtonBox.solved.ToString() + "\n";
        #endregion
        #region __2번째방 입장__
        Start2Room start2Room = FindObjectOfType<Start2Room>(true);
        str += start2Room.first.ToString() + "\n";
        #endregion
        #endregion
        #region __서랍__
        foreach (Drawer drawer in drawers)
        {
            str += drawer.opened.ToString() + "|" + drawer.locked.ToString() + ",";
        }
        str += "\n";
        #endregion
        #region __캐비넷__
        foreach (CabinetDoor cabinet in cabinets)
        {
            str += cabinet.locked.ToString() + "|" + cabinet.opened.ToString() + ",";
        }
        str += "\n";
        #endregion        
        #region __문__
        foreach (PuzzleDoor door in doors)
        {
            str += door.isOpened.ToString() + ",";
        }
        str += "\n";
        #endregion
        #region __자물쇠__
        foreach (Lock locker in locks)
        {
            str += locker.opened.ToString() + ",";
        }
        str += "\n";
        #endregion
        #region __사물함__
        foreach (DrawerDoor drawerDoor in drawerDoors)
        {
            str += drawerDoor.locked.ToString() + "|" + drawerDoor.opened.ToString() + ",";
        }
        str += "\n";
        #endregion
        #region __색깔 퍼즐__
        foreach (ColorPuzzleBox colorPuzzle in colorPuzzles)
        {
            str += colorPuzzle.solved.ToString() + ",";
        }
        str += "\n";
        #endregion
        #region __리액트__
        foreach (ReactInteraction react in reacts)
        {
            str += react.retryInteraction.ToString() + "|" + react.usedItem.ToString() + ",";
        }
        str += "\n";
        #endregion
        #region __밤낮__
        str += GameManager.Instance.IsDaytime.ToString() + "\n";
        #endregion


        #region __3번째방 입장__
        Start3Room start3Room = FindObjectOfType<Start3Room>(true);
        str += start3Room.first.ToString() + "\n";
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
                GameManager.Instance.Inventory.LoadItem((EItemType)System.Enum.Parse(typeof(EItemType), str), null, false);
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
            childPicture.ChangeToFullChildPicture(true);
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
        source = reader.ReadLine();
        values = source.Split(',', '\n');
        HousePicture housePicture = FindObjectOfType<HousePicture>();
        housePicture.ChangePicture((EHousePictureType)System.Enum.Parse(typeof(EHousePictureType), values[0]), null, false);
        housePicture.gateLocked = bool.Parse(values[1]);
        #endregion
        #region __노랑 그림__
        source = reader.ReadLine();
        values = source.Split(',', '\n');
        ArtYellow artYellow = FindObjectOfType<ArtYellow>();
        artYellow.isFirst = bool.Parse(values[0]);
        artYellow.usedFlower = bool.Parse(values[1]);
        artYellow.usedKnife = bool.Parse(values[2]);
        artYellow.isFirstGreen = bool.Parse(values[3]);
        if (bool.Parse(values[4]))
        {
            artYellow.ChangePictureLoad();
        }
        #endregion
        #region __초록 그림__
        source = reader.ReadLine();
        values = source.Split(',', '\n');
        ArtGreen artGreen = FindObjectOfType<ArtGreen>();
        if (bool.Parse(values[0]))
        {
            artGreen.ChangePictureLoad();
        }
        artGreen.isFirst = bool.Parse(values[1]);
        artGreen.isFlowerFirst = bool.Parse(values[2]);
        #endregion
        #region __파랑 그림__
        source = reader.ReadLine();
        values = source.Split(',', '\n');
        ArtBlue artBlue = FindObjectOfType<ArtBlue>();
        if (bool.Parse(values[0]))
        {
            artBlue.ChangePictureLoad();
        }
        artBlue.isFirst = bool.Parse(values[1]);
        artBlue.usedItem = bool.Parse(values[2]);
        #endregion
        #region __빨강 그림__
        source = reader.ReadLine();
        values = source.Split(',', '\n');
        ArtRed artRed = FindObjectOfType<ArtRed>(true);
        if (bool.Parse(values[0]))
        {
            artRed.ChangeArt();
        }
        #endregion
        #region __찢어진 빨강 그림__
        source = reader.ReadLine();
        values = source.Split(',', '\n');
        ShreddedRedCharacterPicture shreddedArtRed = FindObjectOfType<ShreddedRedCharacterPicture>(true);
        shreddedArtRed.isFirst = bool.Parse(values[0]);
        #endregion
        #region __열쇠 자물쇠__
        source = reader.ReadLine();
        values = source.Split(',', '\n');
        LockForKey lockKey = FindObjectOfType<LockForKey>(true);
        if (bool.Parse(values[0]))
        {
            lockKey.Open();
        }
        #endregion
        #region __파란버튼 퍼즐__
        source = reader.ReadLine();
        values = source.Split(',', '\n');
        BlueButtonBox blueButtonBox = FindObjectOfType<BlueButtonBox>(true);
        if (bool.Parse(values[0]))
        {
            blueButtonBox.Open();
        }
        #endregion
        #region __2번째방 입장__
        source = reader.ReadLine();
        values = source.Split(',', '\n');
        Start2Room start2Room = FindObjectOfType<Start2Room>(true);
        start2Room.first = bool.Parse(values[0]);
        #endregion
        #endregion
        #region __서랍__
        source = reader.ReadLine();
        values = source.Split(',', '\n');
        for (int count = 0; count < values.Length; count++)
        {
            if (!string.IsNullOrEmpty(values[count]))
            {
                string[] str = values[count].Split('|');
                if (bool.Parse(str[0]))
                {
                    drawers[count].TranslateDrawer();
                }
                drawers[count].locked = bool.Parse(str[1]);
            }
        }
        #endregion        
        #region __캐비넷__
        source = reader.ReadLine();
        values = source.Split(',', '\n');
        for (int count = 0; count < values.Length; count++)
        {
            if (!string.IsNullOrEmpty(values[count]))
            {
                string[] str = values[count].Split('|');
                cabinets[count].locked = bool.Parse(str[0]);
                if (bool.Parse(str[1]))
                {
                    cabinets[count].Open();
                }
            }
        }
        #endregion
        #region __문__
        source = reader.ReadLine();
        values = source.Split(',', '\n');
        for (int count = 0; count < values.Length; count++)
        {
            if (!string.IsNullOrEmpty(values[count]))
            {
                if (bool.Parse(values[count]))
                {
                    doors[count].Open();
                }
            }
        }
        #endregion
        #region __자물쇠__
        source = reader.ReadLine();
        values = source.Split(',', '\n');
        for (int count = 0; count < values.Length; count++)
        {
            if (!string.IsNullOrEmpty(values[count]))
            {
                if (bool.Parse(values[count]))
                {
                    locks[count].Open();
                }
            }
        }
        #endregion
        #region __사물함__
        source = reader.ReadLine();
        values = source.Split(',', '\n');
        for (int count = 0; count < values.Length; count++)
        {
            if (!string.IsNullOrEmpty(values[count]))
            {
                string[] str = values[count].Split('|');
                if (!bool.Parse(str[0]))
                {
                    drawerDoors[count].Unlock();
                }
                if (bool.Parse(str[1]))
                {
                    drawerDoors[count].TranslateDrawer();
                }
            }
        }
        #endregion
        #region __색깔 퍼즐__
        source = reader.ReadLine();
        values = source.Split(',', '\n');
        for (int count = 0; count < values.Length; count++)
        {
            if (!string.IsNullOrEmpty(values[count]))
            {
                if (!bool.Parse(values[0]))
                {
                    colorPuzzles[count].Open();
                }
            }
        }
        #endregion
        #region __리액트__
        source = reader.ReadLine();
        values = source.Split(',', '\n');
        for (int count = 0; count < reacts.Count; count++)
        {
            string[] str = values[count].Split('|');
            reacts[count].retryInteraction = bool.Parse(str[0]);
            reacts[count].usedItem = bool.Parse(str[1]);
        }
        #endregion
        #region __밤낮__
        source = reader.ReadLine();
        values = source.Split(',', '\n');
        if (!string.IsNullOrEmpty(values[0]))
        {
            GameManager.Instance.IsDaytime = bool.Parse(values[0]);
        }
        #endregion


        #region __3번째방 입장__
        source = reader.ReadLine();
        values = source.Split(',', '\n');
        Start3Room start3Room = FindObjectOfType<Start3Room>(true);
        start3Room.first = bool.Parse(values[0]);
        #endregion



        //Application.quitting += () => { Save(); };


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
