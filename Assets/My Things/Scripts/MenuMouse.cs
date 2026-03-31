using UnityEngine;

public class MenuMouse : MonoBehaviour
{
    private void Awake()
    {
        Cursor.visible = true;
        Destroy(this.gameObject);
    }
}
