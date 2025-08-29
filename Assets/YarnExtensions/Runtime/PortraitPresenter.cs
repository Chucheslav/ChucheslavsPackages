using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

namespace YarnExtensions
{
[AddComponentMenu("Custom Components/Yarn Spinner/Presenters/Portrait Presenter")]
[RequireComponent(typeof(CanvasGroup))]
public class PortraitPresenter : DialoguePresenterBase
{
    [SerializeField] private CharacterListSO characterListSo;
    [SerializeField] private Image portrait;
    
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        portrait.enabled = false;
        _canvasGroup.alpha = 0;
    }

    private void ClearImage()
    {
        portrait.sprite = null;
        portrait.enabled = false;
    }

    public override YarnTask RunLineAsync(LocalizedLine dialogueLine, LineCancellationToken token)
    {
        if(!string.IsNullOrWhiteSpace(dialogueLine.CharacterName) && 
           characterListSo.TryGetCharacterData(dialogueLine.CharacterName, out var characterData))
        {
            portrait.sprite = characterData.portrait;
            portrait.enabled = true;
            return YarnTask.CompletedTask;
        }

        ClearImage();
        return YarnTask.CompletedTask;
    }

    public override YarnTask<DialogueOption> RunOptionsAsync(DialogueOption[] dialogueOptions, CancellationToken cancellationToken) 
        => YarnTask<DialogueOption>.FromResult(null);

    public override YarnTask OnDialogueStartedAsync()
    {
        _canvasGroup.alpha = 1;
        return YarnTask.CompletedTask;
    }

    public override YarnTask OnDialogueCompleteAsync()
    {
        ClearImage();
        _canvasGroup.alpha = 0;
        return YarnTask.CompletedTask;
    }
}
}
