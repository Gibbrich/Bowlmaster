using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject singleton;

                //search if there is a gameobject with this component. If there is, set is as instance
                instance = FindObjectOfType<T>();
                if (instance)
                {
                    singleton = instance.gameObject;
                    DontDestroyOnLoad(singleton);
                }

                // if there are more than 1 instance of singleton, something went wrong
                if (FindObjectsOfType<T>().Length > 1)
                {
                    Debug.LogError(string.Format(
                        "[Singleton] Something went really wrong - there should never be more than 1 {0}! Reopening the scene might fix it.",
                        typeof(T)));
                    return instance;
                }

                // if there is no gameobject with this component, create it and set as instance
                if (instance == null)
                {
                    singleton = new GameObject
                    {
                        name = "(singleton) " + typeof(T)
                    };

                    instance = singleton.AddComponent<T>();
                    DontDestroyOnLoad(singleton);
                }
            }

            return instance;
        }
    }

    protected virtual void Start()
    {
        if (Instance && Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // prevent from creating instance
    protected Singleton()
    {
    }
}