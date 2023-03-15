using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class ImageOverlay : MonoBehaviour {
    public Animator anim;

    Dictionary<string, AnimatorController> images;
    public AnimatorController[] ingredientAnims;

    void Awake() {
        images = new Dictionary<string, AnimatorController>() {
            { "Pork", ingredientAnims[0] },
            { "Sofrito", ingredientAnims[1] },
            { "Onion", ingredientAnims[2] },
            { "Name Root", ingredientAnims[3] },
            { "Calabaza", ingredientAnims[4] },
            { "Sazon", ingredientAnims[5] },
            { "Tomato Paste", ingredientAnims[6] },
            { "Oregano", ingredientAnims[7] },
            { "Corn", ingredientAnims[8] },
            { "Yucca", ingredientAnims[9] },
            { "Malanga", ingredientAnims[10] },
        };
    }

    public void ChangeIngredient(string name) {
        anim.runtimeAnimatorController = images[name];
    }
}
