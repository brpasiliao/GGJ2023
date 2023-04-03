using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Contents : MonoBehaviour {
    public Transform rootImages;
    public GameObject endRoot;

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

            endRoot.SetActive(true);
            foreach (Transform child in rootImages) 
                child.gameObject.SetActive(false);

        } else {
            endRoot.SetActive(false);
            foreach (Transform child in rootImages) 
                child.gameObject.SetActive(false);
            if (cf.transform.childCount != 0 && cf.transform.childCount <= 4) 
                rootImages.GetChild(cf.transform.childCount-1).gameObject.SetActive(true);
            
            int index = 0;
            File content;
            while (index < cf.transform.childCount) {
                content = cf.transform.GetChild(index).GetComponent<File>();
                GameObject aFile = null;

                if (content.fileType == FileType.Folder) {
                    aFile = Instantiate(folder, transform);
                    aFile.GetComponent<ClosedFolder>().folder = content;
                    if (content.encrypted) {
                        aFile.GetComponent<ClosedFolder>().ChangeSprite("locked");
                        aFile.GetComponent<ClosedFolder>().encrypted = content.encrypted;
                        aFile.GetComponent<ClosedFolder>().question = content.question;
                        aFile.GetComponent<ClosedFolder>().answer = content.answer;
                    }
                } else if (content.fileType == FileType.Text) {
                    aFile = Instantiate(text, transform);
                    aFile.GetComponent<NotFolder>().fileType = "text";
                    aFile.GetComponent<NotFolder>().description = content.description;
                } else if (content.fileType == FileType.Image) {
                    aFile = Instantiate(image, transform);
                    aFile.GetComponent<NotFolder>().fileType = "image";
                    aFile.GetComponent<NotFolder>().description = content.description;
                } else if (content.fileType == FileType.Audio) {
                    aFile = Instantiate(audio, transform);
                    aFile.GetComponent<NotFolder>().fileType = "audio";
                }

                aFile.SetActive(true);
                aFile.GetComponent<FoldersNFiles>().ChangeName(content.fileName);
                index++;
            }
        }
    }
}
