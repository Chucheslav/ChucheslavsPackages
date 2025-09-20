using System;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Yarn;
using Yarn.Unity;

namespace YarnExtensions
{
[AddComponentMenu("Custom Components/Yarn Spinner/Yarn Node To TMPText")]
[DisallowMultipleComponent]
public class YarnNodeToTMPText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField][Min(0)] private float nextLineDelay = 1f;
    [SerializeField][Min(0)] private float lastLineDuration = 1f;
    [SerializeField] private bool clearTextAfterCompletion = true;
    
    private DialogueRunner _dialogueRunner;
    
    CancellationTokenSource _cts = new();
	

    private void Awake()
    {
        if(!text) text = GetComponent<TextMeshProUGUI>();
        _dialogueRunner = FindObjectOfType<DialogueRunner>(true);
    }

    public async void ShowText(string nodeID)
    {
        _cts.Cancel();
        
        var program = _dialogueRunner.YarnProject.Program;
        var lineIds = program.LineIDsForNode(nodeID);
        
        _cts = new CancellationTokenSource();
        CancellationToken token = _cts.Token;
        
        foreach (string id in lineIds)
        {
            Line mock = new Line(id, Array.Empty<string>());
            LocalizedLine localizedLine = await _dialogueRunner.LineProvider.GetLocalizedLineAsync(mock, token);
            text.text = localizedLine.Text.Text; 
            await Task.Delay((int) (nextLineDelay * 1000), token);
        }

        if (clearTextAfterCompletion)
        {
            await Task.Delay((int) (lastLineDuration * 1000), token);
            text.text = "";
        }
    }

    private void OnDestroy() => _cts.Cancel();

    private void OnDisable() => _cts.Cancel();
}
}
