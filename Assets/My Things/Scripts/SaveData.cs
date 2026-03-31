[System.Serializable]
public class SaveData
{
    public bool D_lvl1Complete;
    public bool D_lvl2Complete;
    public bool D_lvl3Complete;

    public SaveData(LevelData data)
    {
        D_lvl1Complete = LevelData.lvl1Complete;
        D_lvl2Complete = LevelData.lvl2Complete;
        D_lvl3Complete = LevelData.lvl3Complete;
    }
}
