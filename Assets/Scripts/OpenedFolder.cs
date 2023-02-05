using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenedFolder : FoldersNFiles {
    protected override void Click() {
        if (GameObject.FindObjectOfType<CurrentFolder>().CompareTag("Root")) {
            gameObject.SetActive(false);
        } else {
            StartCoroutine(MoveBackground(false));
            ChangeName(GameObject.FindObjectOfType<CurrentFolder>().GetComponent<File>().fileName);
        }
        File.GoToParent();
    }
}
