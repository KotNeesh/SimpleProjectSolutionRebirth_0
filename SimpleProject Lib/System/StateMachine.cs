using System.Threading;

namespace SimpleProject.Sys
{
    /**
    <summary>
    Машина исполняющая операции и работающая на выделеном потоке.
    </summary>
    */
    public abstract class StateMachine
    {
        private Thread _mainThread;
        protected volatile bool _isExit;
        protected StateMachine()
        {
            _isExit = false;
            _mainThread = new Thread(Go);
        }
        public void Start()
        {
            if (_mainThread != null)
            {
                _mainThread.Start();
            }
        }
        public void Close()
        {
            _isExit = true;
            _mainThread.Join();
            _mainThread = null;
        }
        public void Stop()
        {
            _isExit = true;
        }
        //main_thread
        protected abstract bool Init();
        protected abstract void Deinit();
        protected abstract bool DoAnything();
        private void Go()
        {
            bool ok;
            ok = Init();
            while (ok && !_isExit)
            {
                ok = DoAnything();
            }
            Deinit();
        }
    }
}
