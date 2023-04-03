using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotFolder : FoldersNFiles {
    public GameObject info;
    public GameObject graphic;
    public Dialogue dialogue;
    public GameObject narrator;

    public string fileType;

    public string description = "";

    protected override void Click() {
        overlay.SetActive(true);
        info.SetActive(true);

        if (fileType == "text") {
            StartCoroutine(DisplayGraphic());
            info.GetComponent<TextOverlay>().ChangeWords(description);
        } else if (fileType == "image") {
            StartCoroutine(DisplayGraphic());
            info.GetComponent<ImageOverlay>().ChangeIngredient(fileName.text);
            info.GetComponent<ImageOverlay>().ChangeDescription(description);
        } else if (fileType == "audio") {
            narrator.SetActive(true);
            dialogue.CallPlayDialogue("ending");
        }
    }

    public IEnumerator DisplayGraphic() {
        yield return new WaitForSeconds(0.5f);
        graphic.SetActive(true);
    }
}
