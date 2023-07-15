using System.Reactive.Disposables;

namespace System;

public static class DisposableExtensions
{
    public static void DisposeIfDisposable(this object thing)
    {
        var disposable = thing as IDisposable;
        disposable?.Dispose();
    }

    public static void AddToCompositeDisposable(this IDisposable disposable, CompositeDisposable compositeDisposable) 
        => compositeDisposable?.Add(disposable);

    public static IDisposable SubscribeToEvent<T>(this T object_, Action subscribeAction, Action unsubscribeAction)
    {
        subscribeAction();
        return Disposable.Create(unsubscribeAction);
    }
}
