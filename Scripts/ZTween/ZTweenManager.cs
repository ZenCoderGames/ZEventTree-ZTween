using UnityEngine;
using System.Collections.Generic;

public class ZTweenManager:MonoBehaviour
{
    public struct ZTweenParams
	{
		public float startTime;
		public float timeToEnd;
		public float startDelay;
		public EasingEquations.Ease easeType;
	}

	private static ZTweenManager _instance;
	public static ZTweenManager Instance
	{
		get {
			return _instance;
		}
	}

    List<ZTweenBase> _listOfTweens;
    int _tweenCounter=0;
    ZTweenBase _currentTween;
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _instance = this;

        _listOfTweens = new List<ZTweenBase>();
    }

    void Update()
    {
        // Process Tweens
        for(_tweenCounter=0; _tweenCounter<_listOfTweens.Count; ++_tweenCounter)
        {
            _currentTween = _listOfTweens[_tweenCounter];

            // Check for start delay
            if(_currentTween.WaitForStartDelay())
                continue;

            _currentTween.Update();

            // End after completed time
            if(_currentTween.HasTimeEnded())
            {
                if(_currentTween.HasReturn())
                    _currentTween.Return();
                else
                    EndTween(_currentTween);
            }
        }
	}

    public static ZTweenParams CreateTweenParms(float time, EasingEquations.Ease easeType = EasingEquations.Ease.Linear,
                                                    float startDelay=0, System.Action onCompleteFunc=null)
    {
        ZTweenParams newZTweenParams = new ZTweenParams();
        newZTweenParams.startTime = Time.time;
        newZTweenParams.timeToEnd = time;
        newZTweenParams.startDelay = startDelay;
        newZTweenParams.easeType = easeType;

        return newZTweenParams;
    }

    void EndTween(ZTweenBase tween)
    {
        tween.End();

        _listOfTweens.Remove(tween);
    }

    public void AddTween(ZTweenBase tween)
    {
        _listOfTweens.Add(tween);
    }
}