using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FileType {Folder, Text, Image, Audio};

public class File : MonoBehaviour {
    public FileType fileType;
    public string fileName;
    public string description;

    public static Contents contents; 
    public Contents contentsPublic; 

    void Awake() {
        fileName = gameObject.name;
        contents = contentsPublic;
    }

    public static void GoToParent() {
        CurrentFolder cf = GameObject.FindObjectOfType<CurrentFolder>();
        cf.transform.parent.gameObject.AddComponent<CurrentFolder>();
        Destroy(cf.GetComponent<CurrentFolder>());
        contents.UpdateContents();
    }

    public static void GoTo(File to) {
        CurrentFolder cf = GameObject.FindObjectOfType<CurrentFolder>();
        to.gameObject.AddComponent<CurrentFolder>();
        Destroy(cf.GetComponent<CurrentFolder>());
        contents.UpdateContents();
    }
}
