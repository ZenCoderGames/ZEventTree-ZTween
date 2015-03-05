public class ZTweenFloat:ZTweenBase
{
	float _tweenStartVal, _tweenEndVal;
	public System.Action<float> onUpdateFunc;
    float _currentVal;

    public ZTweenFloat(float startVal, float endVal, float time,
                  EasingEquations.Ease easeType = EasingEquations.Ease.Linear,
                       float startDelay=0, bool returnToOriginal=false):base(time, easeType, startDelay, returnToOriginal)
    {
        _tweenStartVal = startVal;
        _tweenEndVal = endVal;
    }

    override public void Update()
    {
        base.Update();

        _currentVal = EasingEquations.TweenFloat(_currentTime, _tweenStartVal, _tweenEndVal - _tweenStartVal, _tweenParams.timeToEnd, _tweenParams.easeType);
        
        if(onUpdateFunc!=null)
            onUpdateFunc(_currentVal);
    }

    override public void End()
    {
        if(onUpdateFunc!=null)
            onUpdateFunc(_tweenEndVal);
        
        base.End();
    }

	override protected void Reset()
	{
		base.Reset();

		float tempVal = _tweenStartVal;
		_tweenStartVal = _tweenEndVal;
		_tweenEndVal = tempVal;
	}

    override public void Return()
    {
        base.Return();

        float tempVal = _tweenStartVal;
        _tweenStartVal = _tweenEndVal;
        _tweenEndVal = tempVal;
    }
}