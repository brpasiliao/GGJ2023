using System;
using UnityEngine;
using System.Collections;

public static class EventBroker {
    public static event Action<bool> onMoveBackground;

    public static void CallMoveBackground(bool down) {
        onMoveBackground?.Invoke(down);
    }
}
