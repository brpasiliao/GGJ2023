using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotFolder : FoldersNFiles {
    public GameObject info;
    public GameObject graphic;

    public string fileType;

    public string description = "";

    protected override void Click() {
        info.SetActive(true);
        StartCoroutine(DisplayGraphic());

        if (fileType == "text") {
            info.GetComponent<TextOverlay>().ChangeWords(description);
        } else if (fileType == "image") {
            info.GetComponent<ImageOverlay>().ChangeIngredient(fileName.text);
        } else if (fileType == "audio") {

        }
    }

    public IEnumerator DisplayGraphic() {
        yield return new WaitForSeconds(0.5f);
        graphic.SetActive(true);
    }
}
