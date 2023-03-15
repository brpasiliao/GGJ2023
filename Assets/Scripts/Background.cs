using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
    public static RectTransform background;

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
        StartCoroutine(MoveBackground(down));
    }

    public IEnumerator MoveBackground(bool down) {
        if (down) {
            Vector2 end = new Vector2(background.anchoredPosition.x, background.anchoredPosition.y+600);
            while (background.anchoredPosition.y < end.y-5f) {
                background.anchoredPosition = Vector2.Lerp(background.anchoredPosition, end, 5 * Time.deltaTime);
                yield return null;
            }
            background.anchoredPosition = end;

        } else {
            Vector2 end = new Vector2(background.anchoredPosition.x, background.anchoredPosition.y-600);
            while (background.anchoredPosition.y > end.y+5f) {
                background.anchoredPosition = Vector2.Lerp(background.anchoredPosition, end, 5 * Time.deltaTime);
                yield return null;
            }
            background.anchoredPosition = end;
        }

    }
}
