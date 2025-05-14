namespace JabaUtilsLibrary.GameLogic.Interfaces {
    public interface IGameStateBoundModel<GSD> where GSD : IGameStateData {

        #region Methods

        void UpdateWithStateData (GSD stateData);
        GSD GenerateGameStateData ();

        #endregion

    }
}
