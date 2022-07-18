using System.Collections;

namespace Flow
{
    public interface IFlowCommand
    {
        public IEnumerator Execute();
    }
}