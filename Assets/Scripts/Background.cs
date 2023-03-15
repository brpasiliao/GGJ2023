using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Background : MonoBehaviour {
    RectTransform background;
    int level = 5;

    void Awake() {
        background = GetComponent<RectTransform>();
    }

    void OnEnable() {
        EventBroker.onMoveBackground += CallMoveBackground;
    }

    void OnDisable() {
        EventBroker.onMoveBackground -= CallMoveBackground;
    }

    void CallMoveBackground(bool down) {
        StopCoroutine("MoveBackground");
        StartCoroutine("MoveBackground", down);
    }

    public IEnumerator MoveBackground(bool down) {
        if (down) level--;
        else level++;

        float height = 0f;
        if (level == 5) height = -1250f;
        else if (level == 4) height = -650f;
        else if (level == 3) height = -50f;
        else if (level == 2) height = 650f;
        else if (level == 1) height = 1250f;

        Vector2 end = new Vector2(background.anchoredPosition.x, height);
        while (Math.Abs(background.anchoredPosition.y - height) > 1f) {
            background.anchoredPosition = Vector2.Lerp(background.anchoredPosition, end, 5 * Time.deltaTime);
            yield return null;
        }
        background.anchoredPosition = end;


        // if (down) {
        //     Vector2 end = new Vector2(background.anchoredPosition.x, background.anchoredPosition.y+600);
        //     while (background.anchoredPosition.y < end.y-5f) {
        //         background.anchoredPosition = Vector2.Lerp(background.anchoredPosition, end, 5 * Time.deltaTime);
        //         yield return null;
        //     }
        //     background.anchoredPosition = end;

        // } else {
        //     Vector2 end = new Vector2(background.anchoredPosition.x, background.anchoredPosition.y-600);
        //     while (background.anchoredPosition.y > end.y+5f) {
        //         background.anchoredPosition = Vector2.Lerp(background.anchoredPosition, end, 5 * Time.deltaTime);
        //         yield return null;
        //     }
        //     background.anchoredPosition = end;
        // }

    }
}
