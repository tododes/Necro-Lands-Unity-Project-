using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelSlider : TodoBehaviour {

    [SerializeField]
    private PlayerData playerData;

    private RectTransform rectTransform;
    private Vector2 desiredSize;
    private int MaxExp;
    private Text mText;
    private StringBuilder stringBuilder;
	// Use this for initialization
	void Start () {
        rectTransform = Cp<RectTransform>();
        desiredSize = new Vector2(0, rectTransform.position.y);
        mText = Cp_P<Text>();
        stringBuilder = new StringBuilder();
        stringBuilder.Append("Lvl  ");
    }
	
	// Update is called once per frame
	void Update () {
        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        stringBuilder.Append(playerData.Level.ToString());
        mText.text = stringBuilder.ToString();
        MaxExp = 200 + 5 * (playerData.Level - 1) * (playerData.Level - 1) * (playerData.Level - 1);
        desiredSize.y = playerData.Exp * 100f / MaxExp;
        rectTransform.sizeDelta = desiredSize;
	}
}
