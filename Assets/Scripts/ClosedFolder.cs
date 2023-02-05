using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedFolder : FoldersNFiles {
    public OpenedFolder openedFolder;

    public File folder;

    protected override void Click() {
        if (!GameObject.FindObjectOfType<CurrentFolder>().CompareTag("Root")) 
            MoveBackground(true);
            
        transform.parent.GetComponent<AudioSource>().Play();
        // StartCoroutine(MoveBackground(true));
        openedFolder.ChangeName(folder.fileName);
        openedFolder.gameObject.SetActive(true);
        File.GoTo(folder);
    }
}
