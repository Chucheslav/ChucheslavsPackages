using System;
using System.Collections.Generic;
using ScriptableObjectArchitecture.Base;
using Tools;
using UnityEngine;
using UnityEngine.Audio;

namespace ScriptableObjectArchitecture.MonobehaviourAdapters
{
public class VolumeFromVariable : MonoBehaviour
{
    [SerializeField] private List<MixerLink> channelLinks = new();
    [SerializeField] private AudioMixer audioMixer;

    private List<Action<float>> _actions = new();

    private void OnEnable()
    {
        foreach (MixerLink link in channelLinks)
        {
            Action<float> action = f => audioMixer.SetFloat(link.variableName, f.Remap(0,100, -65, 0));
            _actions.Add(action);
            link.floatVariable.Link(action, this);
        }
    }

    private void OnDisable()
    {
        for (var i = 0; i < channelLinks.Count; i++)
        {
            channelLinks[i].floatVariable.Unlink(_actions[i], this);
        }
        
        _actions.Clear();
    }

    [Serializable]
    private class MixerLink
    {
        public string variableName;
        public GenericVariable<float> floatVariable;
    }
}
}
