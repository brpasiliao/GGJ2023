using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class FoldersNFiles : MonoBehaviour, IPointerClickHandler {
    public TMP_Text fileName;
    public RectTransform background;


    // void Start() {
    //     fileName = transform.GetChild(0).GetComponent<TMP_Text>();
    // }

    public virtual void OnPointerClick(PointerEventData eventData) {
        if (eventData.clickCount == 2) {
            Debug.Log ("double click");
            Click();
        }
    }

    protected virtual void Click() {}

    public void ChangeName(string name) {
        fileName.text = name;
    }

    public IEnumerator MoveBackground(bool down) {
        if (down) {
            Vector2 end = new Vector2(background.anchoredPosition.x, background.anchoredPosition.y+600);
            while (background.anchoredPosition.y < end.y) {
                background.anchoredPosition = Vector2.Lerp(background.anchoredPosition, end, 2 * Time.deltaTime);
                Debug.Log("still here");
                yield return null;
            }
        } else {
            Vector2 end = new Vector2(background.anchoredPosition.x, background.anchoredPosition.y-600);
            while (background.anchoredPosition.y > end.y) {
                background.anchoredPosition = Vector2.Lerp(background.anchoredPosition, end, 2 * Time.deltaTime);
                yield return null;
            }
        }
        Debug.Log("done");
    }
}
