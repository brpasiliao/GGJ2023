using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour {
    public GameObject overlay;

    public TMP_Text name1;
    public TMP_Text line1;
    public TMP_Text name2;
    public TMP_Text line2;
    public TMP_Text narrator;

    public RectTransform name1Rect;
    public RectTransform line1Rect;
    public RectTransform name2Rect;
    public RectTransform line2Rect;
    public RectTransform narratorRect;

    TMP_Text currentLine;
    bool clicked = true;
    bool printing = false;

    string[][] intro;
    string[][] ending;

    void Awake() {
        intro = new string[][] {
            new string[] { "Carlos", "Pero tia abuela … this doesn’t look hard at all!" },
            new string[] { "Lucilia", "Have you made Sancocho before?!" },
            new string[] { "Carlos", "Uh ... no? But as long as I follow the recipe, I should be fine." },
            new string[] { "Lucilia", "Si mi nene lindo, but any of us Masas should change the stew, juuust enough, until we make it our very own!" },
            new string[] { "Carlos", "Why would I do that when yours is always the best?" },
            new string[] { "Lucilia", "Hush! You’re not getting out of this!" },
            new string[] { "Carlos", "Hah, alright!" },
            new string[] { "Carlos", "But ... this doesn’t look like your Sancocho." },
            new string[] { "Lucilia", "This is a special recipe!" },
            new string[] { "Lucilia", "Keep this between us nino, but this is my favorite one to have when I feel a bit sad ..." },
            new string[] { "Lucilia", "And I need something hearty and flavorful to remind me that everything will be alright." },
            new string[] { "Carlos", "Oh ... alright! I’ll go get the ingredients then!" },
            new string[] { "Lucilia", "Not yet! We must first find out who made it." },
            new string[] { "Carlos", "Maybe it’s from my dad?" },
            new string[] { "Lucilia", "No, the only thing Reuben ever did right with Sancocho was let your mom make it!" },
            new string[] { "Lucilia", "Now your Uncle Ismael said he wanted to track all changes that the Sancocho recipe has gone through." },
            new string[] { "Lucilia", "So he made all these wonderful … stories about our family and put them all into one big novel on this machine!" },
            new string[] { "Carlos", "Hah! No tia abuela! Uncle Ismael created documentos for each of us and then put everyone into one big folder." },
            new string[] { "Lucilia", "... You think I don’t know what I’m talking about?" },
            new string[] { "Carlos", "N ... no tía abuela ..." },
            new string[] { "Lucilia", "Good! Now go into that book and let’s see what Ismael has." },
        };

        ending = new string[][] {
            new string[] { "Enrique", "Hey everyone! Today we’re making–" },
            new string[] { "Narrator", "A small giggle can be heard in the background. "},
            new string[] { "Enrique", "Angela, ven aqui!" },
            new string[] { "Narrator", "Enrique lets out a slight groan." },
            new string[] { "Enrique", "Today we’re making Sancocho ... with a twist!" },
            new string[] { "Angela", "What’s the twist uncle Enrique?!" },
            new string[] { "Enrique", "If you stay still for a bit, you’ll get to see it!" },
            new string[] { "Angela", "I bet it’s tomato sauce!" },
            new string[] { "Enrique", "Well that’s part–" },
            new string[] { "Narrator", "Footsteps are heard growing more distant." },
            new string[] { "Enrique", "... of it. Ah, she could just see this later." },
            new string[] { "Narrator", "Glass and dishes clink." },
            new string[] { "Enrique", "I’m trying something new with the Sancocho recipe, and I wanted to record it, so you fools won’t forget who made it!" },
            new string[] { "Enrique", "then goes through the entirety of the recipe, being very precise with each measurement and enunciating each syllable, so that no one could misunderstand a thing." },
            new string[] { "Narrator", "All the while, Lucilia is holding her breath, unable to let any air escape." },
            new string[] { "Narrator", "Eventually, Enrique stops what he’s doing and goes to the fridge, taking out a piece of Calabaza." },
            new string[] { "Enrique", "Now this is what we’ve all been waiting for!" },
            new string[] { "Narrator", "He says proudly as he places the Calabaza on the middle of the table." },
            new string[] { "Enrique", "Now I know what everyone is going to say ..." },
            new string[] { "Enrique", "“Oh Enrique you so loco!” this and," },
            new string[] { "Enrique", "“Enrique muy guapo!” that ..." },
            new string[] { "Enrique", "but I will stand firm on this one!" },
            new string[] { "Narrator", "He slams the table."},
            new string[] { "Enrique", "All you have to do is cut a few pieces of Calabaza into the Sancocho and watch it melt right into it." },
            new string[] { "Enrique", "It’s going to add a teeny bit of sweetness to it that’ll make you smile from ear to ear!" },
            new string[] { "Enrique", "But more importantly, the liquid is going to thicken and catch all that delicious flavor inside of it!" },
            new string[] { "Narrator", "As he speaks, Enrique makes a motion of picking up something from the table and eating it. He laughs joyously for a bit, but then lets it die out as he looks directly at the camera," },
            new string[] { "Enrique", "Lucilia ... como estas?" },
            new string[] { "Narrator", "A faint whimper escapes from Lucilia’s mouth as she brings both her hands to her face." },
            new string[] { "Enrique", "I know you’re busy over en Nueva York, but your little brother misses you!" },
            new string[] { "Enrique", "I’m glad you let Angela come visit us though. She looks so much like you that it’s insane!" },
            new string[] { "Narrator", "His smile lowers a bit, but is still noticeable." },
            new string[] { "Enrique", "Me and Juan are going out to war soon, so I thought it’ll be a good idea to give you guys a little something to ..." },
            new string[] { "Enrique", "Wait, not like that!" },
            new string[] { "Enrique", "puts his hands out and laughs." },
            new string[] { "Enrique", "I’m going to come back! Just making sure you all don’t miss me too much!" },
            new string[] { "Narrator", "He then goes back to stirring the stew." },
            new string[] { "Enrique", "Mama!" },
            new string[] { "Enrique", "Make sure that Lucilia watches this the next time she comes to PR." },
            new string[] { "Narrator", "He looks around for a moment." },
            new string[] { "Enrique", "Because I don’t think Angela caught all that. But it’s alright, she’s a kid!" },
            new string[] { "Narrator", "He stops what he’s doing for a moment and looks around once again." },
            new string[] { "Enrique", "Angela! Did you take the onions?!" },
        };
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) clicked = true;
    }

    public void CallPlayDialogue(string d) {
        gameObject.SetActive(true);

        if (d == "intro") {
            StartCoroutine(PlayDialogue(intro));
            Debug.Log("intro");
        }
        else {
            StartCoroutine(PlayDialogue(ending));
            Debug.Log("ending");
        }
    }

    IEnumerator PlayDialogue(string[][] dialogue) {
        name1.text = "";
        name2.text = "";
        line1.text = "";
        line2.text = "";
        narrator.text = "";
        yield return new WaitForSeconds(0.5f);

        foreach (string[] line in dialogue) {
            while (!clicked) yield return null;
            clicked = false;

            if (line[0] == "Narrator")
                currentLine = narrator;
            else if (line[0] == "Carlos" || line[0] == "Enrique") {
                currentLine = line1;
                name1.text = line[0];
            } else {
                currentLine = line2;
                name2.text = line[0];
            }

            printing = true;
            StartCoroutine(PrintLine(line[1]));

            while (printing) yield return null;
        }

        while (!clicked) yield return null;
        clicked = false;

        if (dialogue == intro) {
            overlay.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    IEnumerator PrintLine(string line) {
        currentLine.text = "";

        foreach (char c in line) {
            currentLine.text = currentLine.text + c;
            UpdateRectTransforms();
            
            if (!clicked) yield return new WaitForSeconds(0.03f);
            else {
                currentLine.text = line;
                UpdateRectTransforms();
                clicked = false;
                break;
            }
        }

        printing = false;
    }

    void UpdateRectTransforms() {
        LayoutRebuilder.ForceRebuildLayoutImmediate(name1Rect);
        LayoutRebuilder.ForceRebuildLayoutImmediate(name2Rect);
        LayoutRebuilder.ForceRebuildLayoutImmediate(line1Rect);
        LayoutRebuilder.ForceRebuildLayoutImmediate(line2Rect);
        LayoutRebuilder.ForceRebuildLayoutImmediate(narratorRect);
    }
}
