using UnityEngine;
using UnityEngine.UI;

public class LevelData : MonoBehaviour
{
    public static bool lvl1Complete = false;
    public static bool lvl2Complete = false;
    public static bool lvl3Complete = false;

    [SerializeField] private Button _lvl2;
    [SerializeField] private Button _lvl3;
    [SerializeField] private Button _test;

    public static void UnlockLvl2() => lvl1Complete = true;
    public static void UnlockLvl3() => lvl2Complete = true;
    public static void UnlockTest() => lvl3Complete = true;

    private void Update()
    {
        _lvl2.interactable = lvl1Complete;
        _lvl3.interactable = lvl2Complete;
        _test.interactable = lvl3Complete;
    }
}