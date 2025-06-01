using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D hoverTexture2D;
    public Texture2D initTexture2D;

    public void Start()
    {
        Cursor.SetCursor(initTexture2D, new Vector2(0, 0), CursorMode.ForceSoftware);
    }

    public void SetCursor()
    {
        if (UserModel.Instance.devicePlatform == DevicePlatform.Mobile)
            Cursor.visible = false;
    }

    public void OnMouseHover()
    {
        if (UserModel.Instance.devicePlatform == DevicePlatform.Mobile)
            Cursor.visible = false;

        Cursor.SetCursor(hoverTexture2D, new Vector2(0, 0), CursorMode.ForceSoftware);
    }

    public void OnMouseExit()
    {
        if (UserModel.Instance.devicePlatform == DevicePlatform.Mobile)
            Cursor.visible = false;

        Cursor.SetCursor(initTexture2D, new Vector2(0, 0), CursorMode.ForceSoftware);
    }

    private void Update()
    {
        if (UserModel.Instance.devicePlatform == DevicePlatform.Mobile)
            Cursor.visible = false;

        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(hoverTexture2D, new Vector2(0, 0), CursorMode.ForceSoftware);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(initTexture2D, new Vector2(0, 0), CursorMode.ForceSoftware);
        }
    }
}
