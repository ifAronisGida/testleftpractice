namespace HomeZone.UiObjectInterfaces.Flux
{
    public interface TiFlux : TiApp
    {
        /// <summary>
        /// Saves the and close part in flux.
        /// </summary>
        void SaveAndClosePartInFlux();

        /// <summary>
        /// Changes the solution.
        /// WARNING: This function is language dependent
        /// </summary>
        void ChangeSolution();
    }
}
