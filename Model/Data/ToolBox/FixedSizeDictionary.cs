using System.Collections.Generic;
using EasySave.Exceptions;

namespace EasySave.Model.Data.ToolBox
{
    public class FixedSizeDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        private readonly int maxSize;

        public FixedSizeDictionary(int limit)
        {
            maxSize = limit;
        }

        public new void Add(TKey key, TValue value)
        {
            if (this.Count < maxSize)
                base.Add(key, value);
            else
                throw new NotEnoughSpaceException();
        }
    }
}
