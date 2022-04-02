using System;

namespace Afired.StateMachineSystem {
    
    public abstract class Transition<T1> : ITransition<T1> where T1 : IState {
        
        public abstract bool TestCondition();

        public Type GetState() {

            foreach(Type interfaceType in this.GetType().GetInterfaces()) {
                if(!interfaceType.IsGenericType || interfaceType.GetGenericTypeDefinition() != typeof(ITransition<>))
                    continue;

                return interfaceType.GetGenericArguments()[0];
            }

            throw new Exception();
        }
        
    }
    
}
