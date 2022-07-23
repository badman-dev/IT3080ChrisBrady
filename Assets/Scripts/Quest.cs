using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quests
{
    [System.Serializable]
    public class Quest
    {
        public string title;
        public string description;
        public bool completed = false;

        public Quest(string tit, string desc)
        {
            title = tit;
            description = desc;
        }

        public void Complete()
        {
            completed = true;
        }
    }
}
