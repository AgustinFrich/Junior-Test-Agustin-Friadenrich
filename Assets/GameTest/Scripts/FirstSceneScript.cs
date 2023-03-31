using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using UnityEngine.SceneManagement;

public class FirstSceneScript : MonoBehaviour
{
    public DialogManager DialogManager;

    private void Awake()
    {
        var dialogTexts = new List<DialogData>();

        // Trying another way to introduce changes on the dialogs.
        var pink = "/color:#dd5555/";
        var white = "/color:white/";

        dialogTexts.Add(new DialogData("/size:up/Hi, /size:init/my name is Li. ", "Li"));
        dialogTexts.Add(new DialogData($"Welcome to {pink}my house{white}."));

        // Player choice
        var question = new DialogData("Do you like my place?", "Li");
            question.SelectList.Add("Classic", "Yes, it's classic!");
            question.SelectList.Add("Comfortable", "It is comfortable.");
            question.SelectList.Add("Negative", "No... It's a bit small.");

            question.Callback = () => CheckResponse();

        dialogTexts.Add(question);

        DialogManager.Show(dialogTexts);
    }

    /// <summary>
    /// Checks for the response of the player and gives a propper response. Then, it goes to the next scene.
    /// </summary>
    private void CheckResponse()
    {
        var dialogTexts = new List<DialogData>();

        // Checks result and gives the answer
        switch (DialogManager.Result)
        {
            case "Classic":
                dialogTexts.Add(new DialogData("/emote:Happy/Thank you! That's the answer I expected", "Li"));
                dialogTexts.Add(new DialogData("/emote:Normal/I think you are going to like this, this is classic too.", "Li"));
                break;
            case "Comfortable":
                dialogTexts.Add(new DialogData("/emote:Happy/Thanks, that is nice.", "Li"));
                dialogTexts.Add(new DialogData("/emote:Normal/Let's get more comfortable then.", "Li"));
                break;
            case "Negative":
                dialogTexts.Add(new DialogData("/emote:Sad/Oh... Sorry...", "Li"));
                dialogTexts.Add(new DialogData("/emote:Normal/No problem, I have an idea to make this better.", "Li"));
                break;
        }

        // Saves the response to use it later
        ResponseManager.firstResponse = DialogManager.Result;

        DialogData lastText = new DialogData("/emote:Happy/Let's play a geme!");

        // Change the scene once the last dialog ends.
        lastText.Callback = () =>
        {
             SceneManager.LoadScene(1);
        };

        dialogTexts.Add(lastText);
        DialogManager.Show(dialogTexts);
    }
}
