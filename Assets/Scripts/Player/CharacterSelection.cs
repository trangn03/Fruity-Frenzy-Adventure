// Script reference from https://docs.unity3d.com/ScriptReference/Color-ctor.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    private Image characterImage;
    private int currentCharacter = 0;
    [SerializeField] private Sprite pinkMan;
    [SerializeField] private Sprite maskDude;
    [SerializeField] private Sprite ninjaFrog;
    [SerializeField] private Sprite virtualGuy;
    private Sprite[] sprites = new Sprite[4];
    private Color newColor = new Color(1f, 0.275f, 0.298f);
    private Color oldColor = new Color(0.2f, 1f, 0.4f);
    public Button okButton;
    // Start is called before the first frame update
    void Start()
    {
        sprites[0] = pinkMan;
        sprites[1] = maskDude;
        sprites[2] = ninjaFrog;
        sprites[3] = virtualGuy;
        characterImage = GetComponentInChildren<Image>();
        okButton = GameObject.FindWithTag("selectButton").GetComponent<Button>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (PlayerPrefs.GetInt("characterIndex") == this.currentCharacter) {
            ColorBlock colors = okButton.colors;
            colors.normalColor = newColor;
            okButton.colors = colors;
        }
        else {
            ColorBlock colors = okButton.colors;
            colors.normalColor = oldColor;
            okButton.colors = colors;
        }
    }

    public void nextButton() {
        changeCharacter(this.currentCharacter + 1);
    }

    public void backButton() {
        changeCharacter(this.currentCharacter - 1);
    }

    public void selectButton() {
        PlayerPrefs.SetInt("characterIndex", this.currentCharacter);
    }

    private int clampCharacterValue(int value) {
        if (value < 0) {
            return 3; 
        }
        else if (value > 3) {
            return 0;
        }
        else {
            return value;
        }
    }

    private void changeCharacter(int currentCharacter) {
        this.currentCharacter = clampCharacterValue(currentCharacter);
        characterImage.sprite = sprites[this.currentCharacter];
    }
}
