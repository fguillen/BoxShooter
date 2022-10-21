using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public abstract class AAnimation : MonoBehaviour
{
    [SerializeField] protected bool onAwake = false;

    protected Sequence sequence;
    protected bool playing = false;

    void Start()
    {
        if(onAwake)
            Play();
    }

    [ContextMenu("Play Animation")]
    public void Play()
    {
        KillSequence();
        Reset();

        Animate();

        playing = true;
    }

    protected abstract void Animate();
    protected abstract void Reset();

    void KillSequence()
    {
        sequence?.Kill();
        playing = false;
    }

    void OnDestroy()
    {
        KillSequence();
    }

    void OnDisable()
    {
        KillSequence();
        Reset();
    }

    void OnEnable()
    {
        if(onAwake && !playing)
            Play();
    }

    void OnValidate()
    {
        if(playing)
            Play();
    }
}
