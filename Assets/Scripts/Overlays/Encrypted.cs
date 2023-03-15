using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Encrypted : MonoBehaviour {
    public ClosedFolder closedFolder;
    public GameObject overlay;
    public TMP_InputField answerField;
    public TMP_Text answerBox;
    public TMP_Text questionBox;

    public string answer;
    Color ogColor;

    void Awake() {
        ogColor = answerBox.color;
    }

    public void SetPassword(ClosedFolder cf) {
        gameObject.SetActive(true);
        closedFolder = cf;
        questionBox.text = cf.question;
        answer = cf.answer;
    }

    public void CheckAnswer() {
        if ((closedFolder.fileName.text == "Enrique" && EnriqueCheck()) ||
            (closedFolder.fileName.text != "Enrique" && AnswerCheck())) {
            closedFolder.Unlock();

            overlay.SetActive(false);
            gameObject.SetActive(false);
        } else {
            answerBox.color = Color.red;
        }
    }

    bool AnswerCheck() {
        if (answerBox.text.Remove(answerBox.text.Length - 1, 1).ToLower().Trim() == answer.ToLower().Trim())
            return true;
        else return false;
    }

    bool EnriqueCheck() {
        string parsedAns = answerBox.text.Remove(answerBox.text.Length - 1, 1).ToLower().Trim();
        if (parsedAns.Contains("calabaza")) Debug.Log("calabaza");
        if (parsedAns.Contains("onion")) Debug.Log("onion");
        if (parsedAns.Contains("tomato sauce")) Debug.Log("tomato");

        if (parsedAns.Contains("calabaza") &&
            parsedAns.Contains("onion") &&
            parsedAns.Contains("tomato sauce"))
            return true;
        else return false;
    }

    public void DefaultColor() {
        answerBox.color = ogColor;
    }

    public void ClearText() {
        answerField.text = "";
    }
}
