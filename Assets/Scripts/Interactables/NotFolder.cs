using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotFolder : FoldersNFiles {
    public GameObject info;
    public string fileType;

    protected override void Click() {
        info.SetActive(true);

        if (fileType == "text") {

        } else if (fileType == "image") {
            info.GetComponent<Image>().ChangeIngredient(fileName.text);

        } else if (fileType == "audio") {

        }
    }
}
