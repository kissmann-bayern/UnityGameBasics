using Archero.Input;

namespace Archero {
    namespace Event {
        public interface Event {}
        public abstract class EventBase : Event {
            public string sss = "asd";

            public Keyboard keyboard = null;

            public abstract bool runEvent();
            public abstract void init();
            public EventBase() {
                
            }
        }
    }
}