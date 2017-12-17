using UnityEngine;
using UnityEditor;

public interface IObservable {
    void AddObserver(IObserver o);
    void RemoveObserver(IObserver o);
    void NotifyObservers();
}