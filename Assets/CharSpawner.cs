using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public CharacterData[] characters; // Assign the same list here as in CharacterSelector

    void Start()
    {
        int selectedIndex = PlayerPrefs.GetInt("SelectedCharacterIndex", 0);

        if (selectedIndex >= 0 && selectedIndex < characters.Length)
        {
            GameObject prefab = characters[selectedIndex].characterPrefab;
            if (prefab != null)
            {
                Instantiate(prefab, spawnPoint.position, Quaternion.identity);
            }
            else
            {
                Debug.LogError("Character prefab is missing.");
            }
        }
        else
        {
            Debug.LogError("SelectedCharacterIndex is out of range.");
        }
    }
}