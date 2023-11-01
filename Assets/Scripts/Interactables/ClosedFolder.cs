using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedFolder : FoldersNFiles {
    public OpenedFolder openedFolder;
    public File folder;
    public Encrypted passwordInput;

    public bool encrypted;
    public string question;
    public string answer;

    public Sprite locked;
    public Sprite closed;
    public Sprite open;

    protected override void Click() {
        if (encrypted) {
            overlay.SetActive(true);
            passwordInput.SetPassword(this);

        } else {
            EventBroker.ChangeDepth(-1);

            transform.parent.GetComponent<AudioSource>().Play();
            openedFolder.ChangeName(folder.fileName);
            openedFolder.gameObject.SetActive(true);
            File.GoTo(folder);

            if (!GameObject.FindObjectOfType<CurrentFolder>().CompareTag("Root")) 
                EventBroker.CallMoveBackground(true);
        }
    }

    void OnMouseOver() {
        if (!encrypted) ChangeSprite("open");
    }

    void OnMouseExit() {
        if (!encrypted) ChangeSprite("closed");
    }

    public void Unlock() {
        encrypted = false;
        folder.encrypted = false;
        ChangeSprite("closed");
    }

    public void ChangeSprite(string s) {
        if (s == "open") icon.sprite = open;
        else if (s == "closed") icon.sprite = closed;
        else if (s == "locked") icon.sprite = locked;
    }
}
