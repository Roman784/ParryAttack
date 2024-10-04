using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CountdownTimer
{
    public UnityEvent OnTimerElapsed = new();

    private CountdownTimerView _view;

    public CountdownTimer(CountdownTimerView view)
    {
        _view = view;

        _view.Disable();
    }

    public void Start(int time)
    {
        Coroutines.StartRoutine(StartRoutine(time));
    }

    private IEnumerator StartRoutine(int time)
    {
        _view.Enable();
        _view.UpdateTimer(time);

        yield return Coroutines.StartRoutine(CountTime(time));
        
        _view.Disable();

        OnTimerElapsed.Invoke();
    }

    private IEnumerator CountTime(int time)
    {
        do
        {
            yield return new WaitForSeconds(1);

            time -= 1;
            _view.UpdateTimer(time);
        } 
        while (time > 0);
    }
}
