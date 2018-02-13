using UnityEngine;
using UnityEditor;

public interface IObserver {

    void Update(IObservable o);
   
}