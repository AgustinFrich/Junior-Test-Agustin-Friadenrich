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

    void OnEnable()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("Are you /size:up/ready?", "Li"));
        DialogData goMessage = new DialogData("3.../wait:1f/ 2.../wait:1f/ 1.../wait:1f/ GO! /emote:Happy/ ", "Li");
        goMessage.isSkippable = false;
        
        dialogTexts.Add(goMessage);

        StartCoroutine(MiniGameRoutine());

        dialogManager.Show(dialogTexts);

    }

    IEnumerator MiniGameRoutine()
    {
        yield return new WaitForSeconds(5f);
        controller.SetInteger("change", 1);
        
        yield return new WaitForSeconds(2f);
        controller.SetInteger("change", 2);

        yield return new WaitForSeconds(2f);
        controller.SetInteger("change", 1);

        yield return new WaitForSeconds(2f);
        controller.SetInteger("change", 2);

        yield return new WaitForEndOfFrame();
    }
}
