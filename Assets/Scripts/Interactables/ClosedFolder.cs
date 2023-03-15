using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedFolder : FoldersNFiles {
    public OpenedFolder openedFolder;
    public File folder;

    public Sprite closed;
    public Sprite open;

    protected override void Click() {    
        transform.parent.GetComponent<AudioSource>().Play();
        openedFolder.ChangeName(folder.fileName);
        openedFolder.gameObject.SetActive(true);
        File.GoTo(folder);

        if (!GameObject.FindObjectOfType<CurrentFolder>().CompareTag("Root")) 
            EventBroker.CallMoveBackground(true);
    }

    void OnMouseOver() {
        icon.sprite = open;
    }

    void OnMouseExit() {
        icon.sprite = closed;
    }
}
