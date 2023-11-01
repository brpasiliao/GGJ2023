using System;
using UnityEngine;
using System.Collections;

public static class EventBroker {
    public static event Action<bool> onMoveBackground;
    public static event Action<int> onDepthChange;

    public static void CallMoveBackground(bool down) {
        onMoveBackground?.Invoke(down);
    }

    public static void ChangeDepth(int change) {
        onDepthChange?.Invoke(change);
    }
}
