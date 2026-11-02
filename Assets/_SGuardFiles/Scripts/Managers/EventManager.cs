using System;

public static class EventManager
{
    #region DusmanOlunce
    public static Action<int> _DusmanOldu;
    public static Action<int> _SkorGuncelleAction;

    public static void DusmanYokEdildi(int _Score)
    {
        _DusmanOldu?.Invoke(_Score);
    }

    public static void SkorGuncelle(int _CurrentScore)
    {
        _SkorGuncelleAction?.Invoke(_CurrentScore);
    }
    #endregion

    
}
