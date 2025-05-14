namespace JabaUtilsLibrary.GameLogic.Interfaces {
    public interface IGameRuleBoundModel<GRD> where GRD : IGameRuleData {

        #region Methods

        void ImplementWithRuleData (GRD ruleData);
        GRD GenerateGameRuleData ();

        #endregion

    }
}
