using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotFolder : FoldersNFiles {
    public GameObject info;

    protected override void Click() {
        info.SetActive(true);
    }
}
