using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        //creating readonly instance of singleton class
        //creating new Singleton _instance to store object

        private static T _instance;

        public static T Instance
        {
            get
            {
                //check if instance is null,
                if (_instance == null)
                {
                    //first try to find the object already in the scene
                    _instance = GameObject.FindObjectOfType<T>();

                    if (_instance == null)
                    {
                        // couldnt find the singleton in the scene, so make it
                        GameObject singleton = new GameObject(typeof(T).Name);
                        _instance = singleton.AddComponent<T>();
                    }
                }
                return _instance;
            }

        }
        public virtual void Awake()
        {
            // on Awake check if _instance is null
            if (_instance == null)
            {
                //if null, create _instance of type T and dont destroy
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                //if gameObject already in scene, destroy this instance
                Destroy(gameObject);
            }

        }

    }

}
