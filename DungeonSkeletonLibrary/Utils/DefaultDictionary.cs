using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonSkeletonLibrary.Utils
{
    public class DefaultDictionary<TKey, TVal>
    {
        public TVal defaultVal { get; private set; }

        private Dictionary<TKey, TVal> contents = new Dictionary<TKey, TVal>();

        public TVal this[TKey key]
        {
            get
            {
                EnsureExistance(key);
                return contents[key];
            }

            set
            {
                EnsureExistance(key);
                contents[key] = value;
            }
        }

        public DefaultDictionary(TVal defaultVal)
        {
            this.defaultVal = defaultVal;
        }

        private void EnsureExistance(TKey key)
        {
            //Ensures a key exists
            if (!contents.ContainsKey(key))
            {
                contents.Add(key, defaultVal);
            }
        }
    }
}
