using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class FoldersNFiles : MonoBehaviour, IPointerClickHandler {
    public TMP_Text fileName;

    public virtual void OnPointerClick(PointerEventData eventData) {
        if (eventData.clickCount == 2) {
            Click();
        }
    }

    protected virtual void Click() {}

    public void ChangeName(string name) {
        fileName.text = name;
    }
}
