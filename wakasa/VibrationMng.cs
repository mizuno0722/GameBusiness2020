using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public static class VibrationMng
{
    public static void ShortVibration()
    {
        if (SystemInfo.supportsVibration)
        {
            Vibrate(3);
        }
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
#endif

    private static void Vibrate(long milliseconds)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
            vibrator.Call("vibrate", milliseconds);
#endif
        if (milliseconds >= 1000)
        {
            Handheld.Vibrate();
        }
    }
}
