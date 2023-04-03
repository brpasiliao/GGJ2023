using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ImageOverlay : MonoBehaviour {
    public Animator anim;
    public TMP_Text descriptionBox;

    Dictionary<string, RuntimeAnimatorController> images;
    public RuntimeAnimatorController[] ingredientAnims;

    void Awake() {
        images = new Dictionary<string, RuntimeAnimatorController>() {
            { "Beef", ingredientAnims[0] },
            { "Sofrito", ingredientAnims[1] },
            { "Onion", ingredientAnims[2] },
            { "Name Root", ingredientAnims[3] },
            { "Calabaza", ingredientAnims[4] },
            { "Sazon", ingredientAnims[5] },
            { "Tomato Sauce", ingredientAnims[6] },
            { "Oregano", ingredientAnims[7] },
            { "Corn", ingredientAnims[8] },
            { "Yautia", ingredientAnims[9] },
            { "Malanga", ingredientAnims[10] },
        };
    }

    public void ChangeIngredient(string name) {
        anim.runtimeAnimatorController = images[name];
    }

    public void ChangeDescription(string description) {
        descriptionBox.text = description;
    }
}

