using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogmanager : MonoBehaviour
{
    [SerializeField] GameObject cajadedialogo;
    [SerializeField] Text diálogo;
    [SerializeField] int lettersPerSecond;

    public event Action OnShowDialog;
    public event Action OnHideDialog;
    public static Dialogmanager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    //Dialo dialog;
    int currentLine=0;
    bool isWriting;
    //public IEnumerator ShowDialog(Dialo dialog)
    //{
    //    yield return new WaitForEndOfFrame();

    //    OnShowDialog?.Invoke();
    //    this.dialog = dialog;
    //    cajadedialogo.SetActive(true);
    //    StartCoroutine(TypeDialog(dialog.Lines[0]));
    //}
    //public void HandleUpdate()
    //{
    //    if (Input.GetKeyDown(KeyCode.Z) && isWriting == false)
    //    {
    //        currentLine++;
    //        if (currentLine < dialog.Lines.Count)
    //        {
    //            StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
    //        }
    //        else 
    //        {
    //            currentLine = 0;
    //            cajadedialogo.SetActive(false);
    //            OnHideDialog?.Invoke();
    //        }
    //    }
    //}
    //public IEnumerator TypeDialog(string line)
    //{
    //    isWriting = true;
    //    diálogo.text = "";
    //    foreach (var letter in line.ToCharArray())
    //    { 
    //        diálogo.text += letter;
    //        yield return new WaitForSeconds(1f / lettersPerSecond);
        
    //    }
    //    isWriting = false;
    //}
}
