using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Contents : MonoBehaviour {
    public GameObject root;
    public GameObject folder;
    public GameObject text;
    public GameObject image;
    public GameObject audio;

    public void UpdateContents() {
        foreach (Transform child in transform) 
            Destroy(child.gameObject);

        File cf = GameObject.FindObjectOfType<CurrentFolder>().GetComponent<File>();

        if (cf == null) {
            GameObject aFile = Instantiate(root, transform);
            aFile.SetActive(true);
            aFile.GetComponent<FoldersNFiles>().ChangeName(aFile.transform.GetChild(0).GetComponent<TMP_Text>().text);

        } else {
            int index = 0;
            File content;
            while (index < cf.transform.childCount) {
                content = cf.transform.GetChild(index).GetComponent<File>();
                GameObject aFile = null;

                if (content.fileType == FileType.Folder) {
                    aFile = Instantiate(folder, transform);
                    aFile.GetComponent<ClosedFolder>().folder = content;
                } else if (content.fileType == FileType.Text) {
                    aFile = Instantiate(text, transform);
                } else if (content.fileType == FileType.Image) {
                    aFile = Instantiate(image, transform);
                } else if (content.fileType == FileType.Audio) {
                    aFile = Instantiate(audio, transform);
                }

                aFile.SetActive(true);
                aFile.GetComponent<FoldersNFiles>().ChangeName(content.fileName);
                index++;
            }
        }
    }
}
