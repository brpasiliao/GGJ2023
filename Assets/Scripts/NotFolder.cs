using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotFolder : FoldersNFiles {
    public GameObject info;
    public GameObject graphic;

    protected override void Click() {
        info.SetActive(true);
    }

    public IEnumerator DisplayGraphic() {
        yield return new WaitForSeconds(1);
        graphic.SetActive(true);
    }
}
