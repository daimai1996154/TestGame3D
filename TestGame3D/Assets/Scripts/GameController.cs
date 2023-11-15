using System.Collections;
using System.Collections.Generic;
using System;

public class GameController 
{
    public static Action stopHandMoveEvent;

    public static void StopHandMove()
    {
        stopHandMoveEvent?.Invoke();
    }
}
