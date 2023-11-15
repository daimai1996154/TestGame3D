using System.Collections;
using System.Collections.Generic;
using System;

public class GameController 
{
    public static Action stopHandMoveEvent;
    public static Action openBtnRotateEvent;
    public static Action stopBlenderEvent;
    public static void StopHandMove()
    {
        stopHandMoveEvent?.Invoke();
    }
    public static void OpenBtnRotate()
    {
        openBtnRotateEvent?.Invoke();
    }
    public static void StopBlender()
    {
        stopBlenderEvent?.Invoke();
    }
}
