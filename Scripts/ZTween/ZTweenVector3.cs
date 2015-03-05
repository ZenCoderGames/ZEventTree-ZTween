using UnityEngine;

public class ZTweenVector3:ZTweenBase
{
    Vector3 _tweenStartVal, _tweenEndVal;
	public System.Action<Vector3> OnUpdateFunc;
	float _currentValX, _currentValY, _currentValZ;
	Vector3 _currentVal;
	
	public ZTweenVector3(Vector3 startVal, Vector3 endVal, float time,
	              			EasingEquations.Ease easeType = EasingEquations.Ease.Linear,
                         	float startDelay=0, bool returnToOriginal=false):base(time, easeType, startDelay, returnToOriginal)
	{
		_tweenStartVal = startVal;
		_tweenEndVal = endVal;
		_currentVal = Vector3.zero;
	}
	
	override public void Update()
	{
		base.Update();
		
		_currentValX = EasingEquations.TweenFloat(_currentTime, _tweenStartVal.x, _tweenEndVal.x - _tweenStartVal.x, _tweenParams.timeToEnd, _tweenParams.easeType);
		_currentValY = EasingEquations.TweenFloat(_currentTime, _tweenStartVal.y, _tweenEndVal.y - _tweenStartVal.y, _tweenParams.timeToEnd, _tweenParams.easeType);
		_currentValZ = EasingEquations.TweenFloat(_currentTime, _tweenStartVal.z, _tweenEndVal.z - _tweenStartVal.z, _tweenParams.timeToEnd, _tweenParams.easeType);
        _currentVal.Set(_currentValX, _currentValY, _currentValZ);

		if(OnUpdateFunc!=null)
			OnUpdateFunc(_currentVal);
	}
	
	override public void End()
	{
		if(OnUpdateFunc!=null)
			OnUpdateFunc(_tweenEndVal);
		
		base.End();
	}

	override protected void Reset()
	{
		base.Reset();

		Vector3 tempVal = _tweenStartVal;
		_tweenStartVal = _tweenEndVal;
		_tweenEndVal = tempVal;
	}

    override public void Return()
    {
        base.Return();
        
        Vector3 tempVal = _tweenStartVal;
        _tweenStartVal = _tweenEndVal;
        _tweenEndVal = tempVal;
    }
}