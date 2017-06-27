using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class Monologue : TodoBehaviour {

    [SerializeField] private List<string> quotes = new List<string>();
    [SerializeField] private int index;
    [SerializeField] private Monologue next;
    private string currentQuote;
    private Text quoteText;
    private Image image;
    private StringBuilder stringBuilder;
    private MonologueController controller;

    void OnEnable(){
        quoteText = Cp_C<Text>();
        image = Cp<Image>();
        stringBuilder = new StringBuilder();
        controller = MonologueController.singleton;
        OnChangeIndex();
    }

    void Update(){

        if (Input.GetMouseButtonDown(0) && quoteText.enabled)
        {
            if (index < quotes.Count - 1){
                index++;
                OnChangeIndex();
            }
            else{
                controller.StartNextMonologue(this, next);
            }
        }
        quoteText.text = stringBuilder.ToString();

    }

    public void SetEnable(bool b){
        image.enabled = b;
        quoteText.enabled = b;
    }

    public void OnChangeIndex(){
        if(stringBuilder.Length > 0)
            stringBuilder.Remove(0, stringBuilder.Length);
        currentQuote = quotes[index];
        StartCoroutine(DisplayCharByChar());
    }

    private IEnumerator DisplayCharByChar(){
        for (int i = 0; i < currentQuote.Length; i++){
            Debug.Log(i);
            stringBuilder.Append(currentQuote[i]);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
