using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenedFolder : FoldersNFiles {
    public Sprite open;
    public Sprite closed;

    protected override void Click() {
        EventBroker.ChangeDepth(1);
        
        File.GoToParent();
        GetComponent<AudioSource>().Play();

        if (GameObject.FindObjectOfType<CurrentFolder>().transform.GetChild(0).CompareTag("Root")) { 
            gameObject.SetActive(false);
        } else {
            ChangeName(GameObject.FindObjectOfType<CurrentFolder>().GetComponent<File>().fileName);
            EventBroker.CallMoveBackground(false);
        }
    }

    void OnMouseOver() {
        icon.sprite = closed;
    }

    void OnMouseExit() {
        icon.sprite = open;
    }
}
