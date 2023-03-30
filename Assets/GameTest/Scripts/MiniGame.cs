using Doublsb.Dialog;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    [SerializeField] private DialogManager dialogManager;

    [SerializeField] private Animator controller;
    
    [SerializeField] private GameObject cone01;
    [SerializeField] private GameObject cone02;
    [SerializeField] private GameObject cone03;
        
    [SerializeField] private GameObject ball;
    private int result;

    void OnEnable()
    {
        var dialogTexts = new List<DialogData>();

        StartCoroutine(MiniGameRoutine());

        DialogData goMessage = new DialogData("3.../wait:1/ 2.../wait:1/ 1.../wait:1/ GO!/size:init//emote:Happy//wait:2//emote:Normal//wait:4/", "Li");
        goMessage.isSkippable = false;
        
        dialogTexts.Add(goMessage);

        var gameResult = new DialogData("Where is the ball?", "Li");
            gameResult.SelectList.Add("1", "In the left!");
            gameResult.SelectList.Add("2", "I guess... center!");
            gameResult.SelectList.Add("3", "I'm sure: right!");

        gameResult.Callback = () => Check_MiniGameResult();

        dialogTexts.Add(gameResult);



        dialogManager.Show(dialogTexts);
    }

    void Check_MiniGameResult()
    {

        controller.SetBool("end", true);

        var dialogTexts = new List<DialogData>();

        if (result.ToString() == dialogManager.Result)
        {
            dialogTexts.Add(new DialogData("That is /size:up//emote:Happy/correct!/size:init/", "Li"));
        } else
        {
            dialogTexts.Add(new DialogData("That is... /emote:Sad/wrong, I'm sorry...", "Li"));
        }

        dialogTexts.Add(new DialogData("/emote:Normal/Let's continue"));

        dialogManager.Show(dialogTexts);
    }

    IEnumerator MiniGameRoutine()
    {
        yield return new WaitForSeconds(5f);
        result = Random.Range(1, 4);

        controller.SetInteger("start", result);

        yield return new WaitForSeconds(6f);
    }
}
