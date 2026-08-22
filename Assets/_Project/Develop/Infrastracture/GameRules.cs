using System;
using System.Collections;
using UnityEngine;

public class GameRules
{
    public IEnumerator GameRuleCoroutine(Func<bool> condition, Action callback)
    {
        yield return new WaitUntil(condition);

        callback?.Invoke();
    }
}
