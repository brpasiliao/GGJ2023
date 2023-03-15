using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextOverlay : MonoBehaviour {
    public TMP_Text textbox;

    public void ChangeWords(string words) {
        textbox.text = words;
    }
}
