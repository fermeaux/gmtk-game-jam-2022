using System.Collections;

namespace Flow
{
    public interface IFlowItem
    {
        public IEnumerator Execute();
    }
}