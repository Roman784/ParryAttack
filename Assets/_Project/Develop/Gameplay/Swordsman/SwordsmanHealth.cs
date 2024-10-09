using UnityEngine;

public class SwordsmanHealth
{
    private HealthView _view;

    private int _maxAmount;
    private int _currentAmount;

    public SwordsmanHealth(HealthView view, int amount)
    {
        _view = view;
        _maxAmount = amount;
        _currentAmount = _maxAmount;

        _view.CreateBar(_maxAmount);
    }

    public int Reduce()
    {
        _currentAmount -= 1;
        _currentAmount = Mathf.Clamp(_currentAmount, 0, _maxAmount);

        _view.UpdateBar(_currentAmount);

        return _currentAmount;
    }
}
