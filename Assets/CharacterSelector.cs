using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public CharacterData[] characters; // Drag character ScriptableObjects here
    public Image previewImage;
    private int selectedIndex = 0;
    private int savedIndex = 0;
    public TextMeshProUGUI characterNameText;


    void Start()
    {
        LoadSavedCharacter();
    }

    public void LoadSavedCharacter()
    {
        savedIndex = PlayerPrefs.GetInt("SelectedCharacterIndex", 0);
        selectedIndex = savedIndex;
        UpdatePreview();
    }
    public void NextCharacter()
    {
        selectedIndex = (selectedIndex + 1) % characters.Length;
        UpdatePreview();
    }

    public void PreviousCharacter()
    {
        selectedIndex = (selectedIndex - 1 + characters.Length) % characters.Length;
        UpdatePreview();
    }

    public void ConfirmSelection()
    {
        PlayerPrefs.SetInt("SelectedCharacterIndex", selectedIndex);
        PlayerPrefs.Save();
        savedIndex = selectedIndex;
    }
    public void CancelSelection()
    {
        selectedIndex = savedIndex;
        UpdatePreview();
    }

    private void UpdatePreview()
    {
        previewImage.sprite = characters[selectedIndex].characterSprite;
        characterNameText.text = characters[selectedIndex].characterName;
    }
}