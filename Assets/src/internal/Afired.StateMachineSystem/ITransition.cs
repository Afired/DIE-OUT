namespace Afired.StateMachineSystem {
    
    public interface ITransition<T1, T2> where T1 : IState where T2 : IState {

        public bool TestCondition();

    }
    
}
