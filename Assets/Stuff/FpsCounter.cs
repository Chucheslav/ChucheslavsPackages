using UnityEngine;

namespace UITools
{
public class FpsCounter : MonoBehaviour
{
    [SerializeField]
    private int _frameBufferSize = 30;

    private int[] _fpsBuffer;
    private int _fpsBufferIndex;

    public int LowestFPS { get; private set; }
    public int AverageFPS { get; private set; }
    public int HighestPFS { get; private set; }
    
    private void Awake()
    {
        if (_fpsBuffer != null && _frameBufferSize == _fpsBuffer.Length) return;
        
        if (_frameBufferSize <= 0) _frameBufferSize = 1;

        _fpsBuffer = new int[_frameBufferSize];
        _fpsBufferIndex = 0;
    }

    private void Update()
    {
        _fpsBuffer[_fpsBufferIndex++] = (int)(1f / Time.unscaledDeltaTime);
        _fpsBufferIndex %= _frameBufferSize;
        
        int sum = 0;
        int lowest = int.MaxValue;
        int highest = 0;
        for (int i = 0; i < _frameBufferSize; i++)
        {
            int fps = _fpsBuffer[i];
            sum += fps;
            if (fps > highest) highest = fps;
            if (fps < lowest) lowest = fps;
        }

        HighestPFS = highest;
        LowestFPS = lowest;
        AverageFPS = sum / _frameBufferSize;
    }
}
}
