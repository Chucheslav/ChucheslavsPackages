using UnityEngine;
using Yarn.Unity;

namespace YarnExtensions
{
[AddComponentMenu(menuName: "Сustom Components/Yarn Spinner/Yarn Unity Commands")]
public class YarnUnityCommands : MonoBehaviour
{
    public void RunDialogue(string nodeName)
    {
        var dialogueRunner = FindAnyObjectByType<DialogueRunner>();
        if (!dialogueRunner)
        {
            Debug.LogError("DialogueRunner not found");
            return;
        }
        
        dialogueRunner.StartDialogue(nodeName);
    }
}
}
