using System;
using System.Collections.Generic;
using UnityEngine;

namespace YarnExtensions
{
[CreateAssetMenu(menuName = "Yarn Spinner/Extras/CharacterList")]
public class CharacterListSO : ScriptableObject
{
    [SerializeField] private List<DialogueCharacter> dialogueCharacters = new();

    public bool TryGetCharacterData(string id, out (Sprite portrait, string NameRu, Color nameColor) characterData)
    {
        DialogueCharacter dc = dialogueCharacters.Find(s => s.UniqueID == id);
        if (dc != null)
        {
            characterData.portrait = dc.Portrait;
            characterData.NameRu = dc.NameRu;
            characterData.nameColor = dc.NameColor;
            return true;
        }
        
        characterData.portrait = null;
        characterData.NameRu = null;
        characterData.nameColor = default;
        return false;
    }
        
    [Serializable]
    private class DialogueCharacter
    {
        [field:SerializeField] public string UniqueID { get; private set; }
        [field:SerializeField] public string NameRu { get; private set; }
        [field:SerializeField] public Sprite Portrait { get; private set; }
        
        [field:SerializeField] public Color NameColor { get; private set; }
    }
}
}