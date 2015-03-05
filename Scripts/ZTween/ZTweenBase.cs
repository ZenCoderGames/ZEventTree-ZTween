using UnityEngine;

public class ZTweenBase
{
    public System.Action OnCompleteFunc;
    protected ZTweenManager.ZTweenParams _tweenParams;

    bool _returnToOriginal, _originalReturnToOriginal;
	bool _hasEnded;

	public bool HasEnded
	{
		get
		{
			return _hasEnded;
		}
	}

    protected float _currentTime;

    public ZTweenBase(float time,
                      EasingEquations.Ease easeType = EasingEquations.Ease.Linear,
                      float startDelay=0, bool returnToOriginalVal=false)
    {
        _tweenParams = ZTweenManager.CreateTweenParms(time, easeType, startDelay);
        _returnToOriginal = returnToOriginalVal;
		_originalReturnToOriginal = _returnToOriginal;
    }

	public void Start()
	{
		_hasEnded = false;
		_tweenParams.startTime = Time.time;
		ZTweenManager.Instance.AddTween(this);
	}

    public bool WaitForStartDelay()
    {
        return Time.time - _tweenParams.startTime < _tweenParams.startDelay;
    }

    virtual public void Update()
    {
        _currentTime = Time.time - (_tweenParams.startTime + _tweenParams.startDelay);
    }

    public bool HasTimeEnded()
    {
        return Time.time  >= _tweenParams.startTime + _tweenParams.startDelay + _tweenParams.timeToEnd;
    }

    virtual public void End()
    {
		if(!_returnToOriginal)
		{
			if(OnCompleteFunc!=null)
				OnCompleteFunc();

			_hasEnded = true;
			Reset();
		}
    }

	virtual protected void Reset()
	{
		_returnToOriginal = _originalReturnToOriginal;
	}

    public bool HasReturn()
    {
        return _returnToOriginal;
    }

    virtual public void Return()
    {
        _returnToOriginal = false;
        _tweenParams.startTime = Time.time;
    }
}