using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breadcrumbs : MonoBehaviour {
    public GameObject crumb;
    public GameObject slash;

    Stack<File> crumbs;

    void OnEnable() {
        EventBroker.onDepthChange += ChangeDepth;
    }

    void OnDisable() {
        EventBroker.onDepthChange -= ChangeDepth;
    }

    void ChangeDepth(int change) {

    }
}
