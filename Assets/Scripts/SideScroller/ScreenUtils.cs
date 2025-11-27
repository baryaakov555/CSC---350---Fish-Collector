using UnityEngine;

public static class ScreenUtils
{
    public static float ScreenLeft;
    public static float ScreenRight;
    public static float ScreenTop;
    public static float ScreenBottom;

    public static void Initialize()
    {
        Camera cam = Camera.main;
        Vector3 bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector3 topRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.nearClipPlane));

        ScreenLeft = bottomLeft.x;
        ScreenRight = topRight.x;
        ScreenBottom = bottomLeft.y;
        ScreenTop = topRight.y;
    }
}
